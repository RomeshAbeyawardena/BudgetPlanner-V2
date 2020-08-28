using BudgetPlannerV2.Domains.Data;
using DNI.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlannerV2.Data
{
    public class BudgetPlannerDbContext : EnhancedDbContextBase
    {
        public BudgetPlannerDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Budget> Budget { get; set; }
    }
}
