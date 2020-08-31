using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace BudgetPlannerV2.Cms.Controllers
{
    public abstract class ControllerBase : SurfaceController
    {
        protected JsonNetResult ToJson(object data)
        {
            return ToJson(data, "application/json", Encoding.UTF8);
        }

        protected JsonNetResult ToJson(object data, string contentType, Encoding contentEncoding)
        {
            return new JsonNetResult { 
                Data = data, 
                ContentType = contentType, 
                ContentEncoding = contentEncoding,
                Formatting = Formatting.Indented,
                SerializerSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            };
        }

    }
}
