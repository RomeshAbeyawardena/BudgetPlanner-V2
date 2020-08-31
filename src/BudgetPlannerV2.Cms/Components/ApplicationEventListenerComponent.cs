using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace BudgetPlannerV2.Cms.Components
{
    public class ApplicationEventListenerComponent : IComponent
    {
        public ApplicationEventListenerComponent()
        {
        }

        private void UmbracoApplicationBase_ApplicationInit(object sender, EventArgs e)
        {
            
        }

        public void Initialize()
        {
            UmbracoApplicationBase.ApplicationInit += UmbracoApplicationBase_ApplicationInit;
        }

        public void Terminate()
        {
            UmbracoApplicationBase.ApplicationInit -= UmbracoApplicationBase_ApplicationInit;
        }
    }
}
