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
    public class AdminTheoriesController : Controller
    {
        private readonly ApplicationContext _context;

        public AdminTheoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: AdminTheories
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Theories.Include(t => t.Module);
            return View(await applicationContext.ToListAsync());
        }

        // GET: AdminTheories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theory = await _context.Theories
                .Include(t => t.Module)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (theory == null)
            {
                return NotFound();
            }

            return View(theory);
        }

        // GET: AdminTheories/Create
        public IActionResult Create()
        {
            ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Name");
            return View();
        }

        // POST: AdminTheories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Text,StepNumber,ModuleId")] Theory theory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Name", theory.ModuleId);
            return View(theory);
        }

        // GET: AdminTheories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theory = await _context.Theories.SingleOrDefaultAsync(m => m.Id == id);
            if (theory == null)
            {
                return NotFound();
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Name", theory.ModuleId);
            return View(theory);
        }

        // POST: AdminTheories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Text,StepNumber,ModuleId")] Theory theory)
        {
            if (id != theory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheoryExists(theory.Id))
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
            ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Name", theory.ModuleId);
            return View(theory);
        }

        // GET: AdminTheories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theory = await _context.Theories
                .Include(t => t.Module)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (theory == null)
            {
                return NotFound();
            }

            return View(theory);
        }

        // POST: AdminTheories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theory = await _context.Theories.SingleOrDefaultAsync(m => m.Id == id);
            _context.Theories.Remove(theory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheoryExists(int id)
        {
            return _context.Theories.Any(e => e.Id == id);
        }
    }
}
