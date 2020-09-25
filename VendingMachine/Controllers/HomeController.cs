using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VendingMachine.Data;

namespace VendingMachine.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Точка входа SPA
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}