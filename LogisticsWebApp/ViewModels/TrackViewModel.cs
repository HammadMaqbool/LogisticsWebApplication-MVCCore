using LogisticsWebApp.Models;

namespace LogisticsWebApp.ViewModels;

public class TrackStep
{
    public string Status { get; set; }
    public string Description { get; set; }
}

public class TrackViewModel
{
    public Track TrackInfo { get; set; }
    public List<TrackStep> Steps { get; set; }
}



