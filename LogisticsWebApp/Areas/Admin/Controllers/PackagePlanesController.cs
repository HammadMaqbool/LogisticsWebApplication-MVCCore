﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogisticsWebApp.Data;
using LogisticsWebApp.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LogisticsWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PackagePlanesController : Controller
    {
        private readonly AppDbContext _context;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext?.Session.GetString("flag") != "true")
            {
                context.Result = new RedirectResult("/Admin/Login/Index");
            }
            base.OnActionExecuting(context);
        }

        public PackagePlanesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/PackagePlanes
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_PackagePlane.ToListAsync());
        }

        // GET: Admin/PackagePlanes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packagePlane = await _context.tbl_PackagePlane
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packagePlane == null)
            {
                return NotFound();
            }

            return View(packagePlane);
        }

        // GET: Admin/PackagePlanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PackagePlanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] PackagePlane packagePlane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packagePlane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(packagePlane);
        }

        // GET: Admin/PackagePlanes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packagePlane = await _context.tbl_PackagePlane.FindAsync(id);
            if (packagePlane == null)
            {
                return NotFound();
            }
            return View(packagePlane);
        }

        // POST: Admin/PackagePlanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] PackagePlane packagePlane)
        {
            if (id != packagePlane.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packagePlane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackagePlaneExists(packagePlane.Id))
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
            return View(packagePlane);
        }

        // GET: Admin/PackagePlanes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packagePlane = await _context.tbl_PackagePlane
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packagePlane == null)
            {
                return NotFound();
            }

            return View(packagePlane);
        }

        // POST: Admin/PackagePlanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packagePlane = await _context.tbl_PackagePlane.FindAsync(id);
            if (packagePlane != null)
            {
                _context.tbl_PackagePlane.Remove(packagePlane);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackagePlaneExists(int id)
        {
            return _context.tbl_PackagePlane.Any(e => e.Id == id);
        }
    }
}
