namespace TicketBooking.API;

public static class BookingStore
{
    private static readonly List<Booking> Bookings =
    [
        new Booking
        {
            Id = 1,
            CustomerName = "Ana Hoxha",
            EventName = "Dua Lipa Concert",
            EventType = "Concert",
            EventDate = new DateOnly(2026, 6, 12),
            SeatNumber = "A12",
            TicketQuantity = 2,
            TicketPrice = 35.00m,
            Status = "Booked"
        },
        new Booking
        {
            Id = 2,
            CustomerName = "Bledi Krasniqi",
            EventName = "Tirana Film Festival",
            EventType = "Cinema",
            EventDate = new DateOnly(2026, 7, 5),
            SeatNumber = "B07",
            TicketQuantity = 1,
            TicketPrice = 8.50m,
            Status = "Paid"
        },
        new Booking
        {
            Id = 3,
            CustomerName = "Eriona Shehu",
            EventName = "Albania vs Italy",
            EventType = "Sport",
            EventDate = new DateOnly(2026, 8, 20),
            SeatNumber = "C21",
            TicketQuantity = 3,
            TicketPrice = 25.00m,
            Status = "Cancelled"
        }
    ];

    public static IEnumerable<Booking> GetAll() => Bookings;

    public static Booking? GetById(int id) => Bookings.FirstOrDefault(b => b.Id == id);

    public static Booking Add(Booking booking)
    {
        booking.Id = Bookings.Count == 0 ? 1 : Bookings.Max(b => b.Id) + 1;
        Bookings.Add(booking);
        return booking;
    }

    public static bool Update(int id, Booking booking)
    {
        var existing = Bookings.FirstOrDefault(b => b.Id == id);

        if (existing is null)
        {
            return false;
        }

        existing.CustomerName = booking.CustomerName;
        existing.EventName = booking.EventName;
        existing.EventType = booking.EventType;
        existing.EventDate = booking.EventDate;
        existing.SeatNumber = booking.SeatNumber;
        existing.TicketQuantity = booking.TicketQuantity;
        existing.TicketPrice = booking.TicketPrice;
        existing.Status = booking.Status;

        return true;
    }

    public static bool Delete(int id)
    {
        var existing = Bookings.FirstOrDefault(b => b.Id == id);

        if (existing is null)
        {
            return false;
        }

        Bookings.Remove(existing);
        return true;
    }
}
