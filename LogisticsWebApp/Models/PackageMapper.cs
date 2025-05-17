namespace LogisticsWebApp.Models;

public class PackageMapper
{
    public int Id { get; set; }

    public int PackagePlaneId { get; set; }
    public PackagePlane? PackagePlane { get; set; }

    public int PackagePlanePropertyId { get; set; }
    public PackagePlaneProperty? PackagePlaneProperty { get; set; }
}
