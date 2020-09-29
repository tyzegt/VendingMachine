using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Data;
using VendingMachine.Models;
using VendingMachine.Services;

namespace VendingMachine.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoinService _coinService;

        public ProductController(ApplicationDbContext context, ICoinService coinService)
        {
            _context = context;
            _coinService = coinService;
        }

        [HttpGet]
        public List<Product> GetByCategory(int categoryId)
        {
            return _context.Products
                .Where(x => x.CategoryId == categoryId)
                .OrderBy(x => x.Weight)
                .ToList();
        }

        [HttpPost]
        public List<Product> GetAll()
        {
            return _context.Products
                .OrderByDescending(x => x.Id)
                .ToList();
        }

        [HttpPost]
        public bool Buy(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (PurchaseIsValid(product))
            {
                product.Count--;
                var a = _coinService.GetSum() - product.Price;
                _coinService.Purchase(product.Price);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        private bool PurchaseIsValid(Product product)
        {
            return
                product != null && 
                product.Count > 0 && 
                product.IsAvailable && 
                _coinService.GetSum() >= product.Price;
        }
    }
}
