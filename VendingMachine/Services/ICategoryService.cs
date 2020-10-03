using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Data;

namespace VendingMachine.Services
{
    public interface ICategoryService
    {
        List<ProductCategory> GetAllCategories();
        List<ProductCategory> GetFilledCategories();
        bool AddCategory(ProductCategory category);
        bool EditCategory(ProductCategory category);
        string DeleteCategory(ProductCategory category);
    }
}
