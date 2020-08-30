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
            services.AddDbContextPool<BudgetPlannerIdentityDbContext>(ConfigureDbContext);
            services.RegisterRepositories<BudgetPlannerDbContext>(ConfigureDbContext,
                options =>
                {
                    options.UseDbContextPools = true;
                    options.EnableTracking = false;
                    options.PoolSize = 256;
                    options.SingulariseTableNames = true;
                });
        }

        private void ConfigureDbContext(IServiceProvider serviceProvider, DbContextOptionsBuilder optionsBuilder)
        {
            var applicationSettings = serviceProvider.GetRequiredService<ApplicationSettings>();
                optionsBuilder.UseSqlServer(applicationSettings.DefaultConnectionString);
        }
    }
}
