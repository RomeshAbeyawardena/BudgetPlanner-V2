using BudgetPlannerV2.Broker.Extensions;
using BudgetPlannerV2.Domains.Data;
using DNI.Core.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace BudgetPlannerV2.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .RegisterServiceBroker<Broker.DefaultServiceBroker>()
                .AddControllersWithViews();

            foreach(var service in services)
            {
                Debug.WriteLine("{0}: {1}", service.ServiceType, service.ImplementationType);
            }

            services.AddIdentity<User, Role>()
                .RegisterIdentityServices()
                .AddDefaultTokenProviders();

            services.ConfigureIdentityOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();    
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
