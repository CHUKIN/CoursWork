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
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            //string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            //return Content($"ваша роль: {role}");
           foreach(var role in db.Roles)
            {
                db.Entry(role).Collection(b => b.Users).Load();
                var users = role.Users;
            }
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
    }
}
