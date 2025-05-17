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
    public class PackageMappersController : Controller
    {
        private readonly AppDbContext _context;

        public PackageMappersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/PackageMappers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.tbl_PackageMapper.Include(p => p.PackagePlane).Include(p => p.PackagePlaneProperty);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/PackageMappers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageMapper = await _context.tbl_PackageMapper
                .Include(p => p.PackagePlane)
                .Include(p => p.PackagePlaneProperty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packageMapper == null)
            {
                return NotFound();
            }

            return View(packageMapper);
        }

        // GET: Admin/PackageMappers/Create
        public IActionResult Create()
        {
            ViewData["PackagePlaneId"] = new SelectList(_context.tbl_PackagePlane, "Id", "Name");
            ViewData["PackagePlanePropertyId"] = new SelectList(_context.tbl_PackagePlaneProperties, "Id", "Property");
            return View();
        }

        // POST: Admin/PackageMappers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PackagePlaneId,PackagePlanePropertyId")] PackageMapper packageMapper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packageMapper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PackagePlaneId"] = new SelectList(_context.tbl_PackagePlane, "Id", "Name", packageMapper.PackagePlaneId);
            ViewData["PackagePlanePropertyId"] = new SelectList(_context.tbl_PackagePlaneProperties, "Id", "Property", packageMapper.PackagePlanePropertyId);
            return View(packageMapper);
        }

        // GET: Admin/PackageMappers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageMapper = await _context.tbl_PackageMapper.FindAsync(id);
            if (packageMapper == null)
            {
                return NotFound();
            }
            ViewData["PackagePlaneId"] = new SelectList(_context.tbl_PackagePlane, "Id", "Name", packageMapper.PackagePlaneId);
            ViewData["PackagePlanePropertyId"] = new SelectList(_context.tbl_PackagePlaneProperties, "Id", "Property", packageMapper.PackagePlanePropertyId);
            return View(packageMapper);
        }

        // POST: Admin/PackageMappers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PackagePlaneId,PackagePlanePropertyId")] PackageMapper packageMapper)
        {
            if (id != packageMapper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packageMapper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageMapperExists(packageMapper.Id))
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
            ViewData["PackagePlaneId"] = new SelectList(_context.tbl_PackagePlane, "Id", "Name", packageMapper.PackagePlaneId);
            ViewData["PackagePlanePropertyId"] = new SelectList(_context.tbl_PackagePlaneProperties, "Id", "Property", packageMapper.PackagePlanePropertyId);
            return View(packageMapper);
        }

        // GET: Admin/PackageMappers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageMapper = await _context.tbl_PackageMapper
                .Include(p => p.PackagePlane)
                .Include(p => p.PackagePlaneProperty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packageMapper == null)
            {
                return NotFound();
            }

            return View(packageMapper);
        }

        // POST: Admin/PackageMappers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packageMapper = await _context.tbl_PackageMapper.FindAsync(id);
            if (packageMapper != null)
            {
                _context.tbl_PackageMapper.Remove(packageMapper);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageMapperExists(int id)
        {
            return _context.tbl_PackageMapper.Any(e => e.Id == id);
        }
    }
}
