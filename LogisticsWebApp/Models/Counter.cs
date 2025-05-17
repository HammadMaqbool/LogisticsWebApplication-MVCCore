using System.ComponentModel.DataAnnotations;

namespace LogisticsWebApp.Models;

public class Counter
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Please enter Total Number of Clients")]
    public int Client { get; set; }

    [Required(ErrorMessage = "Please enter Total Number of Projects")]
    public int Projects { get; set; }

    [Required(ErrorMessage = "Please enter Total Number of Hours of Support")]
    public int HoursOfSupport { get; set; }

    [Required(ErrorMessage = "Please enter Total Number of Workers")]
    public int Workers { get; set; }
}
