using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNI.Core.Contracts.Providers;
using DNI.Core.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlannerV2.WebApi.Controllers
{
    [Route("api/{version}/{controller}/{action}")]
    public class ApiController : ExtendedControllerBase
    {
        public ApiController(
            IMediatorProvider mediatorProvider,
            IMapperProvider mapperProvider)
            : base(mediatorProvider, mapperProvider)
        {

        }

        [Authorize]
        public IActionResult GetVersions()
        {
            return Ok(new [] { new { Version =  "1.0",  Status = "Obselete" }, new { Version =  "2.0",  Status = "Current" }  });
        }
    }
}
