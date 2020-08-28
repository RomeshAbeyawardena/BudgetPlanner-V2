using DNI.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Data
{
    public class BudgetPlannerDbContext : EnhancedDbContextBase
    {
        public BudgetPlannerDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }
    }
}
