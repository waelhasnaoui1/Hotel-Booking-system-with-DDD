using Domain.Booking;
using Domain.Customer;
using Infrastructure.Events;

namespace Application;

public class BookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IEventPublisher _eventPublisher;

    public BookingService(IBookingRepository bookingRepository, ICustomerRepository customerRepository, IEventPublisher eventPublisher)
    {
        _bookingRepository = bookingRepository;
        _customerRepository = customerRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task CreateBooking(Guid customerId, decimal totalPrice)
    {
        var customer = _customerRepository.GetCustomerById(customerId);
        if (customer == null)
            throw new ArgumentException("Customer not found");

        var booking = new Booking(Guid.NewGuid(), customer.CustomerId, totalPrice);
        _bookingRepository.Add(booking);
        booking.CompleteBooking();
        
        // Publish the event after saving the booking
        var bookingCreatedEvent = new BookingCreatedEvent(booking);
        await _eventPublisher.PublishAsync(bookingCreatedEvent);
    }
}