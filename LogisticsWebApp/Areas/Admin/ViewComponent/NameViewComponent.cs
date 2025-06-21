namespace LogisticsWebApp.Areas.Admin.ViewComponent;
using Microsoft.AspNetCore.Mvc;

public class NameViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var Name = HttpContext.Session.GetString("Name");
        ViewBag.Name = Name;
        return View();
    }
}
