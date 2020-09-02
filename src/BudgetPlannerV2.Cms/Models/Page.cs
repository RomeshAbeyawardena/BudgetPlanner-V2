using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Cms.Models
{
    public class Page
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Section> Sections { get; set; }
        public IEnumerable<Link> UsefulLinks { get; set; }
        public string Summary { get; set; }
    }
}
