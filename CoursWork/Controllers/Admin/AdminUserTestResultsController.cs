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
    public class AdminUserTestResultsController : Controller
    {
        private readonly ApplicationContext _context;

        public AdminUserTestResultsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: AdminUserTestResults
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.UserTestResulties.Include(u => u.TestResults).Include(u => u.User);
            return View(await applicationContext.ToListAsync());
        }

        // GET: AdminUserTestResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTestResults = await _context.UserTestResulties
                .Include(u => u.TestResults)
                .Include(u => u.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userTestResults == null)
            {
                return NotFound();
            }

            return View(userTestResults);
        }

        // GET: AdminUserTestResults/Create
        public IActionResult Create()
        {
            ViewData["TestResultsId"] = new SelectList(_context.TestResulties, "Id", "Variant");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: AdminUserTestResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TestResultsId,NumberOfTest,Finished")] UserTestResults userTestResults)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTestResults);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TestResultsId"] = new SelectList(_context.TestResulties, "Id", "Variant", userTestResults.TestResultsId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", userTestResults.UserId);
            return View(userTestResults);
        }

        // GET: AdminUserTestResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTestResults = await _context.UserTestResulties.SingleOrDefaultAsync(m => m.Id == id);
            if (userTestResults == null)
            {
                return NotFound();
            }
            ViewData["TestResultsId"] = new SelectList(_context.TestResulties, "Id", "Variant", userTestResults.TestResultsId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", userTestResults.UserId);
            return View(userTestResults);
        }

        // POST: AdminUserTestResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TestResultsId,NumberOfTest,Finished")] UserTestResults userTestResults)
        {
            if (id != userTestResults.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTestResults);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTestResultsExists(userTestResults.Id))
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
            ViewData["TestResultsId"] = new SelectList(_context.TestResulties, "Id", "Variant", userTestResults.TestResultsId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", userTestResults.UserId);
            return View(userTestResults);
        }

        // GET: AdminUserTestResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTestResults = await _context.UserTestResulties
                .Include(u => u.TestResults)
                .Include(u => u.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userTestResults == null)
            {
                return NotFound();
            }

            return View(userTestResults);
        }

        // POST: AdminUserTestResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTestResults = await _context.UserTestResulties.SingleOrDefaultAsync(m => m.Id == id);
            _context.UserTestResulties.Remove(userTestResults);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTestResultsExists(int id)
        {
            return _context.UserTestResulties.Any(e => e.Id == id);
        }
    }
}
