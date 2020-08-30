using BudgetPlannerV2.Cms.Extensions;
using BudgetPlannerV2.Cms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace BudgetPlannerV2.Cms.Controllers
{
    
    public class CmsApiController : SurfaceController
    {
        public CmsApiController()
        {

        }

        [HttpGet]
        public ActionResult GetContent(string route)
        {
            var publishedContent = UmbracoContext.GetPublishedContentByType("page");

            var pages = publishedContent.Select(page => new Page(page));
            
            return Json(pages, JsonRequestBehavior.AllowGet);
        }
    }
}
