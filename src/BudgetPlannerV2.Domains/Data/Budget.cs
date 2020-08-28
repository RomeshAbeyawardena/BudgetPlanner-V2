using System.ComponentModel.DataAnnotations;

namespace BudgetPlannerV2.Domains.Data
{
    public class Budget
    {
        [Key]
        public int Id { get; set; }
    }
}
