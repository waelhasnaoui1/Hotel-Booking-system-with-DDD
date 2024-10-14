namespace Domain.Booking;

public interface IBookingRepository
{
    Booking GetBookingById(Guid bookingId);
    void Add(Booking booking);
}