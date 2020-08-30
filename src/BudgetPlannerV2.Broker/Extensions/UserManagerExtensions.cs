using BudgetPlannerV2.Domains.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Broker.Extensions
{
    public static class UserManagerExtensions
    {
        public static Task<User> FindBySecurityTokenAsync(this UserManager<User> userManager, string securityToken)
        {
            return userManager.Users.SingleOrDefaultAsync(user => user.SecurityStamp == securityToken);
        }
    }
}
