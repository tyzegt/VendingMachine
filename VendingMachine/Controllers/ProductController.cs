using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Data;

namespace VendingMachine.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetByCategory(int categoryId)
        {
            return _context.Products
                .Where(x => x.CategoryId == categoryId)
                .OrderBy(x => x.Weight)
                .ToList();
        }
    }
}
