using Domain.Common;

namespace Domain.Booking;

public class BookingCreatedEvent : IDomainEvent
{
    public Booking Booking { get; }

    public BookingCreatedEvent(Booking booking)
    {
        Booking = booking;
    }
}