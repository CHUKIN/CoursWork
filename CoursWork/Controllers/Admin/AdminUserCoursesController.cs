using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoursWork.Models;

namespace CoursWork.Controllers.Admin
{
    public class AdminUserCoursesController : Controller
    {
        private readonly ApplicationContext _context;

        public AdminUserCoursesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: AdminUserCourses
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserCourses.ToListAsync());
        }

        // GET: AdminUserCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourse = await _context.UserCourses
                .SingleOrDefaultAsync(m => m.IdUser == id);
            if (userCourse == null)
            {
                return NotFound();
            }

            return View(userCourse);
        }

        // GET: AdminUserCourses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminUserCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,IdCouse,Appointment,Finished,ResultPercent")] UserCourse userCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userCourse);
        }

        // GET: AdminUserCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourse = await _context.UserCourses.SingleOrDefaultAsync(m => m.IdUser == id);
            if (userCourse == null)
            {
                return NotFound();
            }
            return View(userCourse);
        }

        // POST: AdminUserCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,IdCouse,Appointment,Finished,ResultPercent")] UserCourse userCourse)
        {
            if (id != userCourse.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCourseExists(userCourse.IdUser))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userCourse);
        }

        // GET: AdminUserCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourse = await _context.UserCourses
                .SingleOrDefaultAsync(m => m.IdUser == id);
            if (userCourse == null)
            {
                return NotFound();
            }

            return View(userCourse);
        }

        // POST: AdminUserCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userCourse = await _context.UserCourses.SingleOrDefaultAsync(m => m.IdUser == id);
            _context.UserCourses.Remove(userCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCourseExists(int id)
        {
            return _context.UserCourses.Any(e => e.IdUser == id);
        }
    }
}
