using Microsoft.AspNetCore.Mvc;

namespace VendingMachine.Controllers
{
    public class TemplateController : Controller
    {
        /// <summary>
        /// SPA entry point
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}