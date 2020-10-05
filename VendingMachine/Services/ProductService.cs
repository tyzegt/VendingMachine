using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Data;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoinService _coinService;

        public ProductService(ApplicationDbContext context, ICoinService coinService)
        {
            _context = context;
            _coinService = coinService;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _context.Products
                .Where(x => x.CategoryId == categoryId)
                .OrderBy(x => x.Weight)
                .ToList();
        }

        public ProductsViewModel GetProducts(ProductsRequest request)
        {
            var result = new ProductsViewModel();

            if(request.CategoryId == 0)
            {
                result.Products = _context.Products
                    .OrderByDescending(x => x.Id)
                    .Skip(request.PageNumber * request.ItemsPerPage)
                    .Take(request.ItemsPerPage)
                    .ToList();
                result.TotalCount = _context.Products
                    .OrderByDescending(x => x.Id).Count();
            } else
            {
                result.Products = _context.Products
                    .Where(x => x.CategoryId == request.CategoryId)
                    .OrderByDescending(x => x.Id)
                    .Skip(request.PageNumber * request.ItemsPerPage)
                    .Take(request.ItemsPerPage)
                    .ToList();
                result.TotalCount = _context.Products
                    .Where(x => x.CategoryId == request.CategoryId)
                    .OrderByDescending(x => x.Id).Count();
            }
            
            return result;
        }

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

        public bool AddProduct(Product product)
        {
            var sameProduct = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (sameProduct != null || product.Price <= 0 || product.Count < 0) return false;
            _context.Add(new Product()
            {
                Description = product.Description,
                CategoryId = product.CategoryId,
                Count = product.Count,
                IsAvailable = product.IsAvailable,
                Name = product.Name,
                PhotoUrl = product.PhotoUrl,
                Price = product.Price,
                Weight = product.Weight
            });
            _context.SaveChanges();
            return true;
        }

        public bool EditProduct(Product editedProduct)
        {
            var product = _context.Products.Where(x => x.Id == editedProduct.Id).AsNoTracking().FirstOrDefault();
            if (product == null || editedProduct.Count < 0 || editedProduct.Price <= 0) return false;
            _context.Update(editedProduct);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteProduct(Product productToDelete)
        {
            var product = _context.Products.Where(x => x.Id == productToDelete.Id).FirstOrDefault();
            if (product == null) return false;
            _context.Remove(product);
            _context.SaveChanges();
            return true;
        }
    }
}
