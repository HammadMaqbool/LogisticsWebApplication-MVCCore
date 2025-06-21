using LogisticsWebApp.Models;

namespace LogisticsWebApp.ViewModels;

public class IndexViewModel
{
    public List<Feature>? _Feature { get; set; }
    public List<Service>? _Services { get; set; }
    public string? _ProfilNumber { get; set; }  
    public List<PackagePlane>? _Package { get; set; }
    public List<Testimonial>? _Testimonial { get; set; }
    public List<FAQ>? _FAQ { get; set; }
}
