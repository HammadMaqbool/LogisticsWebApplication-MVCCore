using System.ComponentModel.DataAnnotations;

namespace LogisticsWebApp.Models;

public class Quote
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter the city of Departure")]
    public string Origin { get; set; }

    [Required(ErrorMessage = "Please enter the city of Destination")]
    public string Destination { get; set; }

    [Required(ErrorMessage = "Please enter the weight of the package in kg")]
    public double Weight { get; set; }

    [Required(ErrorMessage = "Please enter the dimension of the package in cm")]
    public double Dimension { get; set; }

    //Customer Details

    [Required(ErrorMessage = "Please enter the name of the customer")]
    public string Name { get; set; }

    [Required(ErrorMessage ="Please enter your Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter your Phone number - Should be active on WhatsApp")]
    public string Phone { get; set; }

    public string? Message { get; set; }
}
