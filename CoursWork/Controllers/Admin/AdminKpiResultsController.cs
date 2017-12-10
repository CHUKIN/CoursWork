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
    public class AdminKpiResultsController : Controller
    {
        private readonly ApplicationContext _context;

        public AdminKpiResultsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: AdminKpiResults
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.KpiResults.Include(k => k.User);
            return View(await applicationContext.ToListAsync());
        }

        // GET: AdminKpiResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kpiResult = await _context.KpiResults
                .Include(k => k.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (kpiResult == null)
            {
                return NotFound();
            }

            return View(kpiResult);
        }

        // GET: AdminKpiResults/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: AdminKpiResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Result,UserId,Comment")] KpiResult kpiResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kpiResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", kpiResult.UserId);
            return View(kpiResult);
        }

        // GET: AdminKpiResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kpiResult = await _context.KpiResults.SingleOrDefaultAsync(m => m.Id == id);
            if (kpiResult == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", kpiResult.UserId);
            return View(kpiResult);
        }

        // POST: AdminKpiResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Result,UserId,Comment")] KpiResult kpiResult)
        {
            if (id != kpiResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kpiResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KpiResultExists(kpiResult.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", kpiResult.UserId);
            return View(kpiResult);
        }

        // GET: AdminKpiResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kpiResult = await _context.KpiResults
                .Include(k => k.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (kpiResult == null)
            {
                return NotFound();
            }

            return View(kpiResult);
        }

        // POST: AdminKpiResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kpiResult = await _context.KpiResults.SingleOrDefaultAsync(m => m.Id == id);
            _context.KpiResults.Remove(kpiResult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KpiResultExists(int id)
        {
            return _context.KpiResults.Any(e => e.Id == id);
        }
    }
}
