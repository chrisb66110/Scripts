using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NSpaceBLLsVar;
using NSpaceSettingsVar;
using NSpaceContextsVar;
using NSpaceRepositoriesVar;

namespace NameSpaceVar
{
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
            //Disable Model State Valid Filter
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddOptions();

            //Configure settings from appsettings
            services.Configure<NameClassSettingsVar>(Configuration);

            var builder = new ContainerBuilder();
            builder.Populate(services);

            //AddAutoFacRegistration(builder);

            builder.Build();


            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            AddAutoFacRegistration(builder);
        }

        public void AddAutoFacRegistration(ContainerBuilder builder)
        {
            #region API

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            #endregion
            
            #region BLL

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(NameClassBLLVar))).AsImplementedInterfaces();

            #endregion

            #region DAL

            //Register Context
            builder.Register(ctx =>
            {
                var connectionString = ctx.Resolve<NameClassSettingsVar>().ConnectionStrings.DataBaseVarConnectionString;
                var dbOptions = new DbContextOptionsBuilder<NameClassContextVar>().UseNpgsql(connectionString).Options;
                return new NameClassContextVar(dbOptions);
            }).InstancePerDependency();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(NameClassRepositoryVar))).AsImplementedInterfaces();

            #endregion

            #region COMMON

            //Register settings from appsettings
            builder.Register(ctx =>
            {
                var options = ctx.Resolve<IOptions<NameClassSettingsVar>>();
                return options.Value;
            }).InstancePerLifetimeScope();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
