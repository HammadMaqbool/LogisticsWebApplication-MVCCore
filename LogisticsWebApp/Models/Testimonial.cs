using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsWebApp.Models;

public class Testimonial
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Please enter customer Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter customer Designation")]
    public string Designation { get; set; }

    [Required(ErrorMessage = "Please enter customer Review")]
    public string Review { get; set; }

    [Required(ErrorMessage = "Please enter Rating")]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; }

    public string? ImageUrl { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "Please upload a photo")]
    public IFormFile? Phote { get; set; }
}
