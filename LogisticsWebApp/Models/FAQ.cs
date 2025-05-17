using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace LogisticsWebApp.Models;

public class FAQ
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Question is required.")]
    public string Question { get; set; }

    [Required(ErrorMessage = "Answer is required.")]
    public string Answer { get; set; }
}
