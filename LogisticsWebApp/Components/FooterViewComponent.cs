using LogisticsWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsWebApp.Components;

public class FooterViewComponent : ViewComponent
{
    public AppDbContext _context { get; set; }
    public FooterViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var profileData = _context.tbl_Profile.FirstOrDefault();
        return View(profileData);
    }
}
