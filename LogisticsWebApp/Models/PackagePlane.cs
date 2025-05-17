using System.Collections.ObjectModel;

namespace LogisticsWebApp.Models;

public class PackagePlane
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }


    public ICollection<PackageMapper>? _PackageMapper { get; set; } 
}
