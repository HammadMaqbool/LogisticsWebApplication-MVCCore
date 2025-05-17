using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsWebApp.Models;

public class Service
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Discription { get; set; }

    [Required(ErrorMessage = "Slug is required")]
    public string Slug { get; set; }

    //To deal with images. . . 👇
    public string? ImageUrl { get; set; }

    [NotMapped]
    public IFormFile? Photo { get; set; }

}


