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

    /*
     Here are the Status options:
        1. In Transit
        2. Delivered
        3. Out for Delivery
        4. Cancelled
        5. Pending
        6. Returned
        7. Lost
        8. Damaged
        9. Awaiting Pickup
        10. Awaiting Delivery
        11. Awaiting Return
        12. Awaiting Refund
        13. Awaiting Replacement
        14. Awaiting Inspection
        15. Awaiting Approval
        16. Awaiting Payment
        17. Awaiting Confirmation
        18. Awaiting Shipment
        19. Awaiting Collection
        20. Awaiting Dispatch
        21. Dispatched
        22. In Warehouse
        23. Shipped
     */


}
