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
            var applicationContext = _context.UserTheory.Include(u => u.Theory).Include(u => u.User);
            return View(await applicationContext.ToListAsync());
        }

        // GET: AdminUserTheories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTheory = await _context.UserTheory
                .Include(u => u.Theory)
                .Include(u => u.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userTheory == null)
            {
                return NotFound();
            }

            return View(userTheory);
        }

        // GET: AdminUserTheories/Create
        public IActionResult Create()
        {
            ViewData["TheoryId"] = new SelectList(_context.Theories, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: AdminUserTheories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TheoryId,Finished")] UserTheory userTheory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTheory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TheoryId"] = new SelectList(_context.Theories, "Id", "Id", userTheory.TheoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userTheory.UserId);
            return View(userTheory);
        }

        // GET: AdminUserTheories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTheory = await _context.UserTheory.SingleOrDefaultAsync(m => m.Id == id);
            if (userTheory == null)
            {
                return NotFound();
            }
            ViewData["TheoryId"] = new SelectList(_context.Theories, "Id", "Id", userTheory.TheoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userTheory.UserId);
            return View(userTheory);
        }

        // POST: AdminUserTheories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TheoryId,Finished")] UserTheory userTheory)
        {
            if (id != userTheory.Id)
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
                    if (!UserTheoryExists(userTheory.Id))
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
            ViewData["TheoryId"] = new SelectList(_context.Theories, "Id", "Id", userTheory.TheoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userTheory.UserId);
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
                .Include(u => u.Theory)
                .Include(u => u.User)
                .SingleOrDefaultAsync(m => m.Id == id);
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
            var userTheory = await _context.UserTheory.SingleOrDefaultAsync(m => m.Id == id);
            _context.UserTheory.Remove(userTheory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTheoryExists(int id)
        {
            return _context.UserTheory.Any(e => e.Id == id);
        }
    }
}
