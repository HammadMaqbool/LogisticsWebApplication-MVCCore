using System.ComponentModel.DataAnnotations;

namespace LogisticsWebApp.Models;

public class Profile
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Phone is required.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Please provide the Google Map Embed Code")]
    public string GoogleMap { get; set; }

    [Required(ErrorMessage = "Please provide X link")]
    public string x { get; set; }

    [Required(ErrorMessage = "Please provide Facebook")]
    public string Facebook { get; set; }

    [Required(ErrorMessage = "Please provide Instagram")]
    public string Instagram { get; set; }

    [Required(ErrorMessage = "Please provide LinkedIn")]
    public string LinkedIn { get; set; }
}
