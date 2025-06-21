using System.ComponentModel.DataAnnotations;

namespace LogisticsWebApp.Models;

public class Track
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tracking number is required.")]
    public string TrackingNumber { get; set; }

    [Required(ErrorMessage = "Please enter the Dispatch location")]
    public string Source { get; set; }

    [Required(ErrorMessage = "Please enter the Destination location")]
    public string Destination { get; set; }

    [Required(ErrorMessage = "Please enter the Status of Order")]
    public string Status { get; set; }
}
