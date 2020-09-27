using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Data;

namespace VendingMachine.Controllers
{
    [Route("[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<ProductCategory> GetCategories()
        {
            return _context
                .ProductCategories
                .OrderBy(x => x.Weight)
                .ToList();
        }
    }
}
