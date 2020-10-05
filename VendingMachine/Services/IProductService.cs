using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Data;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public interface IProductService
    {
        bool Buy(int productId);
        ProductsViewModel GetProducts(ProductsRequest request);
        List<Product> GetByCategory(int categoryId);
        bool AddProduct(Product product);
        bool EditProduct(Product editedProduct);
        bool DeleteProduct(Product productToDelete);
    }
}
