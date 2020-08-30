using BudgetPlannerV2.Data;
using BudgetPlannerV2.Services.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Broker.Extensions
{
    public static class IdentityServicesExtensions
    {
        public static IdentityBuilder RegisterIdentityServices(this IdentityBuilder builder)
        {
            return builder
                .AddEntityFrameworkStores<BudgetPlannerIdentityDbContext>()
                .AddPasswordValidator<PasswordValidator>();
        }

        public static IServiceCollection ConfigureIdentityOptions(this IServiceCollection services)
        {
            return services.Configure<IdentityOptions>(options =>
               {
                   // Password settings.
                   options.Password.RequireDigit = true;
                   options.Password.RequireLowercase = true;
                   options.Password.RequireNonAlphanumeric = true;
                   options.Password.RequireUppercase = true;
                   options.Password.RequiredLength = 6;
                   options.Password.RequiredUniqueChars = 1;

                   // Lockout settings.
                   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                   options.Lockout.MaxFailedAccessAttempts = 5;
                   options.Lockout.AllowedForNewUsers = true;

                   // User settings.
                   options.User.AllowedUserNameCharacters =
                  "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/=";
                   options.User.RequireUniqueEmail = false;
               });
        }
    }
}
