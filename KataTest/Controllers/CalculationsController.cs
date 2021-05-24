using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KataTest.Models;
using Microsoft.AspNetCore.Authorization;

namespace KataTest.Controllers
{
    [Authorize]
    public class CalculationsController : Controller
    {
        private readonly KataDbContex _context;

        public CalculationsController(KataDbContex context)
        {
            _context = context;
        }

        // GET: Calculations
        public async Task<IActionResult> Index()
        {
            return View(await _context.calculations.ToListAsync());
        }

        // GET: Calculations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculation = await _context.calculations
                .FirstOrDefaultAsync(m => m.id == id);
            if (calculation == null)
            {
                return NotFound();
            }

            return View(calculation);
        }

        // GET: Calculations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calculations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FristNumber,SecondNumer,Result")] Calculation calculation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calculation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calculation);
        }

        // GET: Calculations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculation = await _context.calculations.FindAsync(id);
            if (calculation == null)
            {
                return NotFound();
            }
            return View(calculation);
        }

        // POST: Calculations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FristNumber,SecondNumer,Result")] Calculation calculation)
        {
            if (id != calculation.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calculation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalculationExists(calculation.id))
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
            return View(calculation);
        }

        // GET: Calculations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculation = await _context.calculations
                .FirstOrDefaultAsync(m => m.id == id);
            if (calculation == null)
            {
                return NotFound();
            }

            return View(calculation);
        }

        // POST: Calculations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calculation = await _context.calculations.FindAsync(id);
            _context.calculations.Remove(calculation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalculationExists(int id)
        {
            return _context.calculations.Any(e => e.id == id);
        }
    }
}
