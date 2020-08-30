using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Web.Controllers
{
    
    public class HomeController : DefaultController
    {
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
    }
}
