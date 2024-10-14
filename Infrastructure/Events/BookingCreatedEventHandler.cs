using Domain.Booking;
using Domain.Payment;

namespace Infrastructure.Events;

public class BookingCreatedEventHandler : IEventHandler<BookingCreatedEvent>
{
    private readonly IPaymentRepository _paymentRepository;

    public BookingCreatedEventHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }


    public async Task HandleAsync(BookingCreatedEvent eventToHandle)
    {
        var payment = new Payment
        {
            BookingId = eventToHandle.Booking.BookingId,
            Amount = eventToHandle.Booking.TotalPrice, // Assuming TotalPrice is in Booking
            Status = PaymentStatus.Pending
        };

        await _paymentRepository.AddAsync(payment);
    }
}
