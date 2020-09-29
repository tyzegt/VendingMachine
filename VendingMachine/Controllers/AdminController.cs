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
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody] AuthRequest request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login.ToLower() == request.Login.ToLower());
            if (user == null || user.Password != request.Password) 
                return BadRequest();
            else
            {
                HttpContext.Session.SetInt32("LoggedIn", 1);
                return Ok();
            }
        }

        [HttpGet]
        public bool IsLoggedIn()
        {
            return HttpContext.Session.GetInt32("LoggedIn") == 1;
        }
    }
}
