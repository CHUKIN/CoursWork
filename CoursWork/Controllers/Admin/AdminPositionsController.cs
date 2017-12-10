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
    public class AdminPositionsController : Controller
    {
        private readonly ApplicationContext _context;

        public AdminPositionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: AdminPositions
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Positions.Include(p => p.Departament);
            return View(await applicationContext.ToListAsync());
        }

        // GET: AdminPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Positions
                .Include(p => p.Departament)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: AdminPositions/Create
        public IActionResult Create()
        {
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "Name");
            return View();
        }

        // POST: AdminPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DepartamentId")] Position position)
        {
            if (ModelState.IsValid)
            {
                _context.Add(position);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "Name", position.DepartamentId);
            return View(position);
        }

        // GET: AdminPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Positions.SingleOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "Name", position.DepartamentId);
            return View(position);
        }

        // POST: AdminPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DepartamentId")] Position position)
        {
            if (id != position.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(position);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(position.Id))
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
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "Name", position.DepartamentId);
            return View(position);
        }

        // GET: AdminPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Positions
                .Include(p => p.Departament)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: AdminPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _context.Positions.SingleOrDefaultAsync(m => m.Id == id);
            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }
    }
}
