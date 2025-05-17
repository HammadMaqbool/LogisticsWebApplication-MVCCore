using LogisticsWebApp.Models;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<ContactUs> tbl_ContactUs { get; set; }
    public DbSet<Counter> tbl_Counter { get; set; }
    public DbSet<FAQ> tbl_FAQ { get; set; }
    public DbSet<Feature> tbl_Feature { get; set; }
    public DbSet<PackagePlane> tbl_PackagePlane { get; set; }
    public DbSet<PackagePlaneProperty> tbl_PackagePlaneProperties { get; set; }
    public DbSet<Profile> tbl_Profile { get; set; }
    public DbSet<Quote> tbl_Quote { get; set; }
    public DbSet<Service> tbl_Service { get; set; }
    public DbSet<Testimonial> tbl_Testimonial { get; set; }
    public DbSet<Track> tbl_Track { get; set; }
    public DbSet<PackageMapper> tbl_PackageMapper { get; set; }

}
