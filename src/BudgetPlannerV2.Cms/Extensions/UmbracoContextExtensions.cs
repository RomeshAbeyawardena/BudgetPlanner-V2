using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace BudgetPlannerV2.Cms.Extensions
{
    public static class UmbracoContextExtensions
    {
        public static IEnumerable<IPublishedContent> GetPublishedContentByType(this UmbracoContext umbracoContext, string typeAlias)
        {
            var contentType = umbracoContext.Content.GetContentType(typeAlias);

            if(contentType == null)
            {
                throw new NullReferenceException();
            }

            return umbracoContext.Content.GetByContentType(contentType);
        }
    }
}
