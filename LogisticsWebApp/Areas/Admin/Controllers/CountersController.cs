using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogisticsWebApp.Data;
using LogisticsWebApp.Models;

namespace LogisticsWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountersController : Controller
    {
        private readonly AppDbContext _context;

        public CountersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Counters
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_Counter.ToListAsync());
        }

        // GET: Admin/Counters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var counter = await _context.tbl_Counter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (counter == null)
            {
                return NotFound();
            }

            return View(counter);
        }

        // GET: Admin/Counters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Counters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Client,Projects,HoursOfSupport,Workers")] Counter counter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(counter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(counter);
        }

        // GET: Admin/Counters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var counter = await _context.tbl_Counter.FindAsync(id);
            if (counter == null)
            {
                return NotFound();
            }
            return View(counter);
        }

        // POST: Admin/Counters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Client,Projects,HoursOfSupport,Workers")] Counter counter)
        {
            if (id != counter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(counter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CounterExists(counter.Id))
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
            return View(counter);
        }

        // GET: Admin/Counters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var counter = await _context.tbl_Counter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (counter == null)
            {
                return NotFound();
            }

            return View(counter);
        }

        // POST: Admin/Counters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var counter = await _context.tbl_Counter.FindAsync(id);
            if (counter != null)
            {
                _context.tbl_Counter.Remove(counter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CounterExists(int id)
        {
            return _context.tbl_Counter.Any(e => e.Id == id);
        }
    }
}
