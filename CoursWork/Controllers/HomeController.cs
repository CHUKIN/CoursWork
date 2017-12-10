using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursWork.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CoursWork.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            //string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            //return Content($"ваша роль: {role}");
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        
        public IActionResult Profile()
        {
            var user = db.Users.FirstOrDefault(i => i.Login == User.Identity.Name);
            db.Entry(user).Reference(i => i.Position).Load();
            db.Entry(user).Reference(i => i.Role).Load();
            return View(user);
        }
        
    }
}
