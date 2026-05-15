namespace TicketBooking.API;

public class Booking
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string EventName { get; set; } = string.Empty;
    public string EventType { get; set; } = string.Empty;
    public DateOnly EventDate { get; set; }
    public string SeatNumber { get; set; } = string.Empty;
    public int TicketQuantity { get; set; }
    public decimal TicketPrice { get; set; }
    public string Status { get; set; } = string.Empty;
}
