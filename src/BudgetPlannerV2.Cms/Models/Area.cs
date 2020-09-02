using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Cms.Models
{
    public class Area
    {
        public string Title { get; set; }
        public IEnumerable<Page> Page { get; set; }
    }
}
