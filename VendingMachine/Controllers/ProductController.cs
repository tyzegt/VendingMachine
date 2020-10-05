using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Data;
using VendingMachine.Models;
using VendingMachine.Services;

namespace VendingMachine.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> GetByCategory(int categoryId)
        {
            return _productService.GetByCategory(categoryId);
        }

        [HttpPost]
        public ProductsViewModel GetProducts([FromBody] ProductsRequest request)
        {
            return _productService.GetProducts(request);
        }

        [HttpPost]
        public bool Buy(int productId)
        {
            return _productService.Buy(productId);
        }

        [HttpPost]
        public bool AddProduct([FromBody] Product product)
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == 1)
                return _productService.AddProduct(product);
            else
                return false;
        }

        [HttpPost]
        public bool EditProduct([FromBody] Product product)
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == 1)
                return _productService.EditProduct(product);
            else
                return false;
        }

        [HttpPost]
        public bool DeleteProduct([FromBody] Product product)
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == 1)
                return _productService.DeleteProduct(product);
            else
                return false;
        }
    }
}
