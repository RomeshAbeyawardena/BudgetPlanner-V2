using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Cms.Models
{
    public class FormGroup
    {
        public IEnumerable<Alert> Alerts { get; set; }
        public IEnumerable<Section> Sections { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
    }
}
