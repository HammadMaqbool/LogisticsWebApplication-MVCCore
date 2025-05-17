using System.ComponentModel.DataAnnotations;

namespace LogisticsWebApp.Models;

public class Feature
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Please enter the name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter the description")]
    public string Description { get; set; }

    [Required(ErrorMessage ="Please enter the bootStrap Icon")]
    public string BootStrapIcon { get; set; }
}
