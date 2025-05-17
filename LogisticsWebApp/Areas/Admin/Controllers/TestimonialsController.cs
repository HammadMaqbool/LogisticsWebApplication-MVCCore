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
    public class TestimonialsController : Controller
    {
        private readonly AppDbContext _context;
        public IWebHostEnvironment env { get; set; }

        public TestimonialsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Admin/Testimonials
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_Testimonial.ToListAsync());
        }

        // GET: Admin/Testimonials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonial = await _context.tbl_Testimonial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testimonial == null)
            {
                return NotFound();
            }

            return View(testimonial);
        }

        // GET: Admin/Testimonials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Testimonials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                string ImageName = testimonial.Phote.FileName.ToString();

                var FolderPath = Path.Combine(env.WebRootPath, "Uploads/testimonial_images");
                var ImagePath = Path.Combine(FolderPath, ImageName);

                var FileStream = new FileStream(ImagePath, FileMode.Create);
                testimonial.Phote.CopyTo(FileStream);
                FileStream.Dispose();

                testimonial.ImageUrl = ImageName;

                _context.Add(testimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testimonial);
        }

        // GET: Admin/Testimonials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonial = await _context.tbl_Testimonial.FindAsync(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            return View(testimonial);
        }

        // POST: Admin/Testimonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Designation,Review,Rating,ImageUrl")] Testimonial testimonial)
        {
            if (id != testimonial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testimonial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestimonialExists(testimonial.Id))
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
            return View(testimonial);
        }

        // GET: Admin/Testimonials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonial = await _context.tbl_Testimonial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testimonial == null)
            {
                return NotFound();
            }

            return View(testimonial);
        }

        // POST: Admin/Testimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testimonial = await _context.tbl_Testimonial.FindAsync(id);
            if (testimonial != null)
            {
                _context.tbl_Testimonial.Remove(testimonial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestimonialExists(int id)
        {
            return _context.tbl_Testimonial.Any(e => e.Id == id);
        }
    }
}
