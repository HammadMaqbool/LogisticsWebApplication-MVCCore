using Microsoft.AspNetCore.Mvc;

namespace LogisticsWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("services")]
        public IActionResult Services()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("pricing")]
        public IActionResult Pricing()
        {
            return View();
        }

        [Route("get-a-quote")]
        public IActionResult GetAQuote()
        {
            return View();
        }
    }
}
