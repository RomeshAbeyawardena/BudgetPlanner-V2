using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Cms.Models
{
    public class Section
    {
        public string Reference { get; set; }
        public IEnumerable<Form> Forms { get; set; }
        public IEnumerable<Link> UsefulLinks { get; set; }
        public string Summary { get; set; }
    }
}
