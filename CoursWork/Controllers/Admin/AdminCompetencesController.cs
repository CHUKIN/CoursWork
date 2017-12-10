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
    public class AdminCompetencesController : Controller
    {
        private readonly ApplicationContext _context;

        public AdminCompetencesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: AdminCompetences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Competences.ToListAsync());
        }

        // GET: AdminCompetences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competences = await _context.Competences
                .SingleOrDefaultAsync(m => m.Id == id);
            if (competences == null)
            {
                return NotFound();
            }

            return View(competences);
        }

        // GET: AdminCompetences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminCompetences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Norm")] Competences competences)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competences);
        }

        // GET: AdminCompetences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competences = await _context.Competences.SingleOrDefaultAsync(m => m.Id == id);
            if (competences == null)
            {
                return NotFound();
            }
            return View(competences);
        }

        // POST: AdminCompetences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Norm")] Competences competences)
        {
            if (id != competences.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competences);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetencesExists(competences.Id))
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
            return View(competences);
        }

        // GET: AdminCompetences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competences = await _context.Competences
                .SingleOrDefaultAsync(m => m.Id == id);
            if (competences == null)
            {
                return NotFound();
            }

            return View(competences);
        }

        // POST: AdminCompetences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competences = await _context.Competences.SingleOrDefaultAsync(m => m.Id == id);
            _context.Competences.Remove(competences);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetencesExists(int id)
        {
            return _context.Competences.Any(e => e.Id == id);
        }
    }
}
