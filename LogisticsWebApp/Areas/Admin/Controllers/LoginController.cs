using LogisticsWebApp.Data;
using LogisticsWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController(AppDbContext _db) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            var AuthenticUser = _db.tbl_User.Where(opt => opt.Username == user.Username && opt.Password == user.Password).FirstOrDefault();
            if(AuthenticUser is not null)
            {
                HttpContext.Session.SetString("flag", "true");
                HttpContext.Session.SetString("Name", AuthenticUser.Name);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            } 
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home", new {area = "" });
        }
    }
}
