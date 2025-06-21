using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogisticsWebApp.Data;
using LogisticsWebApp.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LogisticsWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext?.Session.GetString("flag") != "true")
            {
           
                context.Result = new RedirectResult("/Admin/Login/Index");
            }
            base.OnActionExecuting(context);
        }

        private readonly AppDbContext _context;

        public ContactUsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ContactUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_ContactUs.ToListAsync());
        }

        // GET: Admin/ContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.tbl_ContactUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        

        

        // GET: Admin/ContactUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.tbl_ContactUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // POST: Admin/ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactUs = await _context.tbl_ContactUs.FindAsync(id);
            if (contactUs != null)
            {
                _context.tbl_ContactUs.Remove(contactUs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult SendMessage(ContactUs contact)
        {
            if (ModelState.IsValid)
            {
                _context.tbl_ContactUs.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Contact", "Home");
            }
            return View(contact);
        }

    }
}
