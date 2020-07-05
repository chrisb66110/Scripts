using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using APIBase.Api.Configurations;
using APIBase.Common.Constants;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Catalogue.Bll.Blls.CategoryBll;
using Catalogue.Common.Settings;
using Catalogue.Dal.Contexts;
using Catalogue.Dal.Repositories.CategoryRepository;

namespace Catalogue.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DbContext to Migrations
            var connectionString = Configuration.GetConnectionString("CatalogueConnectionString");
            services.AddDbContextPool<CatalogueContext>(options =>
            {
                options.UseNpgsql(connectionString, opt =>
                {
                    opt.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            });

            //Configure Auto mapper
            var assemblies = new List<Assembly>
            {
                Assembly.GetAssembly(typeof(CategoryRepository)),
                Assembly.GetAssembly(typeof(CategoryBll)),
                Assembly.GetAssembly(typeof(Startup))
            };
            services.AddAutoMapper(assemblies);
            
            services.AddOptions();

            //Configure settings from appsettings
            services.Configure<CatalogueSettings>(Configuration);

            var builder = new ContainerBuilder();
            builder.Populate(services);

            AddAutoFacRegistration(builder);

            var container = builder.Build();

            //Configure Authentication
            services.ConfigureAuthentication<CatalogueSettings>(container, "tempkey.rsa");
            
            //Configure Cors allowed
            services.ConfigureCors<CatalogueSettings>(container, "GET", "POST", "PUT");
            
            //Configure HealthChecks
            services.AddHealthChecks();

            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            AddAutoFacRegistration(builder);
        }

        public void AddAutoFacRegistration(ContainerBuilder builder)
        {
            #region Api

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            #endregion
            
            #region Bll

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CategoryBll))).AsImplementedInterfaces();

            #endregion

            #region Dal

            //Register Context
            builder.Register(ctx =>
            {
                var connectionString = ctx.Resolve<CatalogueSettings>().ConnectionStrings.CatalogueConnectionString;
                var dbOptions = new DbContextOptionsBuilder<CatalogueContext>().UseNpgsql(connectionString).Options;
                return new CatalogueContext(dbOptions);
            }).InstancePerDependency();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CategoryRepository))).AsImplementedInterfaces();

            #endregion

            #region Common

            //Register settings from appsettings
            builder.Register(ctx =>
            {
                var options = ctx.Resolve<IOptions<CatalogueSettings>>();
                return options.Value;
            }).InstancePerLifetimeScope();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            //app.UseHttpsRedirection();

            app.UseRouting();

			app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseHealthChecks("/HealthChecks");

            app.UseCors(BaseConstants.ALLOWED_CORS_POLICY);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

