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
    public class AdminUserTheoriesController : Controller
    {
        private readonly ApplicationContext _context;

        public AdminUserTheoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: AdminUserTheories
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserTheory.ToListAsync());
        }

        // GET: AdminUserTheories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTheory = await _context.UserTheory
                .SingleOrDefaultAsync(m => m.IdUser == id);
            if (userTheory == null)
            {
                return NotFound();
            }

            return View(userTheory);
        }

        // GET: AdminUserTheories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminUserTheories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,IdTheory,Finished")] UserTheory userTheory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTheory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTheory);
        }

        // GET: AdminUserTheories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTheory = await _context.UserTheory.SingleOrDefaultAsync(m => m.IdUser == id);
            if (userTheory == null)
            {
                return NotFound();
            }
            return View(userTheory);
        }

        // POST: AdminUserTheories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,IdTheory,Finished")] UserTheory userTheory)
        {
            if (id != userTheory.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTheory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTheoryExists(userTheory.IdUser))
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
            return View(userTheory);
        }

        // GET: AdminUserTheories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTheory = await _context.UserTheory
                .SingleOrDefaultAsync(m => m.IdUser == id);
            if (userTheory == null)
            {
                return NotFound();
            }

            return View(userTheory);
        }

        // POST: AdminUserTheories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTheory = await _context.UserTheory.SingleOrDefaultAsync(m => m.IdUser == id);
            _context.UserTheory.Remove(userTheory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTheoryExists(int id)
        {
            return _context.UserTheory.Any(e => e.IdUser == id);
        }
    }
}
