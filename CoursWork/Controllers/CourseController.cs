using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursWork.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursWork.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationContext db;
        public CourseController(ApplicationContext context)
        {
            db = context;
            //DatabaseInitialize(); // добавляем пользователя и роли в бд
        }

        public IActionResult MyCourse()
        {
            var user = db.Users.FirstOrDefault(i => i.Login == User.Identity.Name);

            var allCourses = db.Courses;
            foreach(var course in allCourses)
            {
                db.Entry(course).Collection(i => i.UserCourses);
            }
            var courses = allCourses.Where(i => i.UserCourses.FirstOrDefault(j => j.UserId == user.Id).Appointment==true);
            foreach (var course in courses)
            {
                db.Entry(course).Collection(b => b.UserCourses).Load();

                foreach (var userCourses in course.UserCourses)
                {
                    db.Entry(userCourses).Reference(b => b.User).Load();
                }
            }

            return View(courses);
        }

        public IActionResult AllCourse()
        {
            var courses = db.Courses;
            foreach (var course in courses)
            {
                db.Entry(course).Collection(b => b.UserCourses).Load();

                foreach (var userCourses in course.UserCourses)
                {
                    db.Entry(userCourses).Reference(b => b.User).Load();
                }
            }

            return View(courses);
        }

        public IActionResult SubscribeCourse(int id)
        {
            var user = db.Users.FirstOrDefault(i => i.Login == User.Identity.Name);

            var subCourse = db.UserCourses.FirstOrDefault(i => i.UserId == user.Id && i.CourseId == id);
            if (subCourse == null)
            {
                subCourse = new UserCourse { User = user, CourseId = id };
                db.UserCourses.Add(subCourse);
            }
            subCourse.Appointment = true;
            db.SaveChanges();

            return RedirectToAction("AllCourse", "Course");
        }

        public IActionResult UnSubscribeCourse(int id)
        {
            var user = db.Users.FirstOrDefault(i => i.Login == User.Identity.Name);

            db.UserCourses.FirstOrDefault(i => i.UserId == user.Id && i.CourseId == id).Appointment = false;
            db.SaveChanges();

            return RedirectToAction("AllCourse", "Course");
        }

        public IActionResult UnSubscribeMyCourse(int id)
        {
            var user = db.Users.FirstOrDefault(i => i.Login == User.Identity.Name);

            db.UserCourses.FirstOrDefault(i => i.UserId == user.Id && i.CourseId == id).Appointment = false;
            db.SaveChanges();

            return RedirectToAction("MyCourse", "Course");
        }


        public IActionResult OpenCourse(int id)
        {
            var course = db.Courses.Find(id);

            db.Entry(course).Collection(b => b.Modules).Load();

            foreach (var module in course.Modules)
            {
                db.Entry(module).Collection(b => b.Tests).Load();
                db.Entry(module).Collection(b => b.Theories).Load();

                foreach (var theory in module.Theories)
                {
                    db.Entry(theory).Collection(b => b.UserTheorys).Load();

                    foreach (var userTheorys in theory.UserTheorys)
                    {
                        db.Entry(userTheorys).Reference(b => b.User).Load();
                    }
                }

                foreach (var test in module.Tests)
                {
                    db.Entry(test).Collection(b => b.TestResulties).Load();

                    foreach (var testResults in test.TestResulties)
                    {
                        db.Entry(testResults).Collection(b => b.UserTestResults).Load();
                    }

                    test.UserTestResulties = db.UserTestResulties.Where(i => i.NumberOfTest == test.Id).ToList();
                }
            }

            return View(course);
        }

        public IActionResult OpenTheory(int id)
        {
            return View(db.Theories.Find(id));
        }

        public IActionResult OpenTest(int id)
        {
            var test = db.Tests.Find(id);
            db.Entry(test).Collection(i => i.TestResulties).Load();
            test.Module = db.Modules.Find(test.ModuleId);
            return View(test);
        }

        public IActionResult FinishTheory(int id)
        {
            var theory = db.Theories.Find(id);
            theory.Module = db.Modules.Find(theory.ModuleId);

            var user = db.Users.FirstOrDefault(i => i.Login == User.Identity.Name);

            var userTheory = db.UserTheory.FirstOrDefault(i => i.User == user && i.Theory == theory);
            if (userTheory == null)
            {
                userTheory = new UserTheory { User = user, Theory = theory };
                db.UserTheory.Add(userTheory);
            }
            userTheory.Finished = true;
            db.SaveChanges();

            return RedirectToAction("OpenCourse", "Course", new { id = theory.Module.CourseId });
        }

        public IActionResult FinishTest(int id, string result)
        {
            var test = db.Tests.Find(id);
            db.Entry(test).Reference(i => i.Module).Load();
            db.Entry(test).Collection(i => i.TestResulties).Load();

            var user = db.Users.FirstOrDefault(i => i.Login == User.Identity.Name);

            var resultTest = db.TestResulties.FirstOrDefault(i => i.Variant == result);

            var userResultTest = db.UserTestResulties.FirstOrDefault(i => i.User == user && i.NumberOfTest == test.Id);
            if (userResultTest == null)
            {
                userResultTest = new UserTestResults { User = user, NumberOfTest = test.Id };
                db.UserTestResulties.Add(userResultTest);
            }
            userResultTest.TestResults = resultTest;
            userResultTest.Finished = true;
            db.SaveChanges();

            return RedirectToAction("OpenCourse", "Course", new { id = test.Module.CourseId });
        }
    }
}