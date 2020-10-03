using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Data;

namespace VendingMachine.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddCategory(ProductCategory category)
        {
            var sameCategory = _context.ProductCategories
                .FirstOrDefault(x => x.Name.ToLower() == category.Name.ToLower());
            if (sameCategory != null || string.IsNullOrEmpty(category.Name)) return false;

            _context.Add(new ProductCategory()
            {
                Name = category.Name,
                Weight = category.Weight
            });
            _context.SaveChanges();

            return true;
        }

        public string DeleteCategory(ProductCategory categoryToDelete)
        {
            var category = _context.ProductCategories.FirstOrDefault(x => x.Id == categoryToDelete.Id);
            if (category == null) return "null";
            if (_context.Products.Any(x => x.CategoryId == category.Id)) return "error";

            _context.Remove(category);
            _context.SaveChanges();

            return "ok";
        }

        public bool EditCategory(ProductCategory categoryToEdit)
        {
            var category = _context.ProductCategories.FirstOrDefault(x => x.Id == categoryToEdit.Id);
            if (category == null) return false;

            category.Name = categoryToEdit.Name;
            category.Weight = categoryToEdit.Weight;
            _context.SaveChanges();

            return true;
        }

        public List<ProductCategory> GetAllCategories()
        {
            return _context
                .ProductCategories
                .OrderBy(x => x.Weight)
                .ToList();
        }

        public List<ProductCategory> GetFilledCategories()
        {
            return _context
                .ProductCategories
                .Where(x => _context.Products.Select(y => y.CategoryId).Distinct().Contains(x.Id))
                .OrderBy(x => x.Weight)
                .ToList();
        }
    }
}
