using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using ElectronicShop.Queries;
using ElectronicShop.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ElectronicShop.Datas;

namespace ElectronicShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<ElectronicDbContext>(options => options.UseInMemoryDatabase("foo"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IElectronicQueries, ElectronicQueries> ();
            services.AddTransient<IElectronicCommands, ElectronicCommands> ();
            services.AddSingleton<IConfiguration> (Configuration);
            services.AddApiVersioning();
            // Plug Autofac
            var container = new ContainerBuilder ();
            container.Populate (services);
            // FOR COMMAND HANDLERS
            // container.RegisterType<EmployerEngagementCommandBus> ().As<ICommandBus> ();
            // Register CommandHandlers
            // container.RegisterAssemblyTypes (typeof (Startup).GetTypeInfo ().Assembly)
            // .AsClosedTypesOf (typeof (IHandleCommand<>))
            // .AsImplementedInterfaces ()
            // .InstancePerLifetimeScope ();
            return new AutofacServiceProvider (container.Build ());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
