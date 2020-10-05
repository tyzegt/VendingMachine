using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Data;
using VendingMachine.Services;

namespace VendingMachine.Controllers
{
    [Route("[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryService _categoryService;

        public CategoryController(ApplicationDbContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<ProductCategory> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }

        [HttpGet]
        public List<ProductCategory> GetFilledCategories()
        {
            return _categoryService.GetFilledCategories();
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] ProductCategory category)
        {
            if (HttpContext.Session.GetInt32("LoggedIn") != 1) return BadRequest();
            var result = _categoryService.AddCategory(category);
            if (result) return Ok();
            else return BadRequest();
        }

        [HttpPost]
        public IActionResult EditCategory([FromBody] ProductCategory category)
        {
            if (HttpContext.Session.GetInt32("LoggedIn") != 1) return BadRequest();
            var result = _categoryService.EditCategory(category);
            if (result) return Ok();
            else return BadRequest();
        }

        [HttpPost]
        public string DeleteCategory([FromBody] ProductCategory category)
        {
            if (HttpContext.Session.GetInt32("LoggedIn") != 1) return "error";
            return _categoryService.DeleteCategory(category);
        }
    }
}
