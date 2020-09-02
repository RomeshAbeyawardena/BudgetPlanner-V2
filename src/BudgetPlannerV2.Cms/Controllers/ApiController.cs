using BudgetPlannerV2.Cms.ViewModels;
using BudgetPlannerV2.Cms.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using AutoMapper;

namespace BudgetPlannerV2.Cms.Controllers
{
    public class ApiController : ExtendedSurfaceController
    {
        public ApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetContent()
        {
            var publishedContent = UmbracoContext.GetPublishedContentByType("page");

            var pages = publishedContent.Select(page => (Page) page).ToArray();

            var sectionList = new List<SectionItem>();
            var formGroups = new List<FormGroup>();
            foreach(var page in pages)
            {
                foreach(var section in page.Sections)
                {
                    sectionList.Add(section);
                    formGroups.Add((FormGroup)section.Form);
                }
            }

           var mappedPages = mapper.Map<IEnumerable<Models.Page>>(pages);

            return ToJson(mappedPages);
        }

        private readonly IMapper mapper;
    }

    public class ExtendedSurfaceController : SurfaceController
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
