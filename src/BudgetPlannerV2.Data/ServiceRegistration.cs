using BudgetPlannerV2.Domains;
using DNI.Core.Contracts;
using DNI.Core.Services.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BudgetPlannerV2.Data
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.RegisterRepositories<BudgetPlannerDbContext>(
                (serviceProvider, dbContextOptionsBuilder) => { 
                    var applicationSettings = serviceProvider.GetRequiredService<ApplicationSettings>(); 
                    dbContextOptionsBuilder.UseSqlServer(applicationSettings.DefaultConnectionString);
                },
                options => options.UseDbContextPools = true);
        }
    }
}
