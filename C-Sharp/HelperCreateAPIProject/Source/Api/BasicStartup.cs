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
using NSpaceBLLsVar;
using NSpaceSettingsVar;
using NSpaceContextsVar;
using NSpaceRepositoriesVar;

namespace NameSpaceVar
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
            var connectionString = Configuration.GetConnectionString("DataBaseVarConnectionString");
            services.AddDbContextPool<NameClassContextVar>(options =>
            {
                options.UseNpgsql(connectionString, opt =>
                {
                    opt.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            });

            //Configure Auto mapper
            var assemblies = new List<Assembly>
            {
                Assembly.GetAssembly(typeof(NameClassRepositoryVar)),
                Assembly.GetAssembly(typeof(NameClassBLLVar)),
                Assembly.GetAssembly(typeof(Startup))
            };
            services.AddAutoMapper(assemblies);
            
            services.AddOptions();

            //Configure settings from appsettings
            services.Configure<NameClassSettingsVar>(Configuration);

            var builder = new ContainerBuilder();
            builder.Populate(services);

            AddAutoFacRegistration(builder);

            var container = builder.Build();

            //Configure Authentication
            services.ConfigureAuthentication<NameClassSettingsVar>(container, "tempkey.rsa");
            
            //Configure Cors allowed
            services.ConfigureCors<NameClassSettingsVar>(container, "GET", "POST", "PUT");
            
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

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(NameClassBLLVar))).AsImplementedInterfaces();

            #endregion

            #region Dal

            //Register Context
            builder.Register(ctx =>
            {
                var connectionString = ctx.Resolve<NameClassSettingsVar>().ConnectionStrings.DataBaseVarConnectionString;
                var dbOptions = new DbContextOptionsBuilder<NameClassContextVar>().UseNpgsql(connectionString).Options;
                return dbOptions;
            }).InstancePerDependency();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(NameClassRepositoryVar))).AsImplementedInterfaces();

            #endregion

            #region Common

            //Register settings from appsettings
            builder.Register(ctx =>
            {
                var options = ctx.Resolve<IOptions<NameClassSettingsVar>>();
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