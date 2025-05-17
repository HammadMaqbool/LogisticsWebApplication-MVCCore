using System.ComponentModel.DataAnnotations;

namespace LogisticsWebApp.Models
{
    public class PackagePlaneProperty
    {
        
        public int Id { get; set; }
        public string Property { get; set; }

        public ICollection<PackageMapper>? _PackageMapper { get; set; }

    }
}
