using LogisticsWebApp.Data;
using LogisticsWebApp.Models;
using LogisticsWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebApp.Controllers
{
    public class HomeController(AppDbContext _context) : Controller
    {
      
        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new();
            indexViewModel._Feature = _context.tbl_Feature.ToList();
            indexViewModel._Services = _context.tbl_Service.ToList();
            indexViewModel._ProfilNumber = _context.tbl_Profile.FirstOrDefault()?.Phone;
            indexViewModel._Package = _context.tbl_PackagePlane?.Include(pp => pp._PackageMapper).ThenInclude(mapper => mapper.PackagePlaneProperty)
                .ToList();
            indexViewModel._Testimonial = _context.tbl_Testimonial.ToList();
            indexViewModel._FAQ = _context.tbl_FAQ.ToList();

            return View(indexViewModel);
        }

        [Route("about")]
        public IActionResult About()
        {
            var CounterData = _context.tbl_Counter?.FirstOrDefault();
            return View(CounterData);
        }

        [Route("services")]
        public IActionResult Services()
        {
            var services = _context.tbl_Service.ToList();
            return View(services);
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            ContactViewModel contactView = new();
            contactView._Profile = _context.tbl_Profile.FirstOrDefault();
            return View(contactView);
        }

        [Route("pricing")]
        public IActionResult Pricing()
        {
            var PackageWithProps = _context.tbl_PackagePlane?.Include(pp => pp._PackageMapper).ThenInclude(mapper => mapper.PackagePlaneProperty)
            .ToList();
            return View(PackageWithProps);
        }

        [Route("get-a-quote")]
        public IActionResult GetAQuote()
        {
            return View();
        }

        [HttpPost]
        [Route("get-a-quote")]
        public IActionResult GetAQuote(Quote quote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quote);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(quote);
        }


        [HttpGet]
        public IActionResult OrderTracker(string TrackingNumber)
        {
            var TrackInfo = _context.tbl_Track.FirstOrDefault(t => t.TrackingNumber == TrackingNumber);

            var list_of_steps = new List<TrackStep>
            {
                new TrackStep{ Status = "Dispatched", Description = "Your order has been dispatched successfully." },
                new TrackStep{ Status = "In transint", Description = "Your package is on the way to the destination." },
                new TrackStep{ Status = "At Destination Office", Description = "Your order has been reached on the destination office." },
                new TrackStep{ Status = "Out for Delivery", Description = "Your order is out for delivery." },
                new TrackStep{ Status = "Delivered", Description = "Your order has been delivered successfully." }
            };

         
            TrackViewModel TVM = new();
            TVM.TrackInfo = TrackInfo;
            TVM.Steps = list_of_steps;

            return View(TVM);
        }
    }
}
