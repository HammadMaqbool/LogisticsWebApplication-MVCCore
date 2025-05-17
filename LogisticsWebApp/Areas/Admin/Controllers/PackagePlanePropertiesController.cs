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
    public class PackagePlanePropertiesController : Controller
    {
        private readonly AppDbContext _context;

        public PackagePlanePropertiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/PackagePlaneProperties
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_PackagePlaneProperties.ToListAsync());
        }

        // GET: Admin/PackagePlaneProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packagePlaneProperty = await _context.tbl_PackagePlaneProperties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packagePlaneProperty == null)
            {
                return NotFound();
            }

            return View(packagePlaneProperty);
        }

        // GET: Admin/PackagePlaneProperties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PackagePlaneProperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Property")] PackagePlaneProperty packagePlaneProperty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packagePlaneProperty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(packagePlaneProperty);
        }

        // GET: Admin/PackagePlaneProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packagePlaneProperty = await _context.tbl_PackagePlaneProperties.FindAsync(id);
            if (packagePlaneProperty == null)
            {
                return NotFound();
            }
            return View(packagePlaneProperty);
        }

        // POST: Admin/PackagePlaneProperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Property")] PackagePlaneProperty packagePlaneProperty)
        {
            if (id != packagePlaneProperty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packagePlaneProperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackagePlanePropertyExists(packagePlaneProperty.Id))
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
            return View(packagePlaneProperty);
        }

        // GET: Admin/PackagePlaneProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packagePlaneProperty = await _context.tbl_PackagePlaneProperties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packagePlaneProperty == null)
            {
                return NotFound();
            }

            return View(packagePlaneProperty);
        }

        // POST: Admin/PackagePlaneProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packagePlaneProperty = await _context.tbl_PackagePlaneProperties.FindAsync(id);
            if (packagePlaneProperty != null)
            {
                _context.tbl_PackagePlaneProperties.Remove(packagePlaneProperty);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackagePlanePropertyExists(int id)
        {
            return _context.tbl_PackagePlaneProperties.Any(e => e.Id == id);
        }
    }
}
