using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoursWork.Controllers
{
    public class EstemationController : Controller
    {
        private ApplicationContext db;
        public EstemationController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var Allusers = db.Users;
            foreach (var user in Allusers)
            {
                db.Entry(user).Reference(i => i.Role).Load();
            }
            var users = Allusers.Where(i => i.Role.Name == "User");
            foreach (var user in users)
            {
                db.Entry(user).Reference(i => i.Position).Load();
                db.Entry(user.Position).Collection(i => i.Competences).Load();
            }
            return View(users);
        }

        [HttpPost]
        public IActionResult SelectUser(int id, int count)
        {
            var user = db.Users.Find(id);

            db.Entry(user).Reference(i => i.Role).Load();

            db.Entry(user).Reference(i => i.Position).Load();
            db.Entry(user.Position).Collection(i => i.Competences).Load();

            ViewBag.AllCount = count;

            return View(user);
        }
    }
}