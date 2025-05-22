using LogisticsWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public int NumberOfServices { get; set; }
        public int NumberOfTestimonials { get; set; }
        public int NumberOfMessages { get; set; }
        public int NumberOfPackages { get; set; }

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
