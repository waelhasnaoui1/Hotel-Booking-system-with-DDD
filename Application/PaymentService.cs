using Domain.Booking;
using Domain.Payment;

namespace Application;

public class PaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IBookingRepository _bookingRepository;

    public PaymentService(IPaymentRepository paymentRepository, IBookingRepository bookingRepository)
    {
        _paymentRepository = paymentRepository;
        _bookingRepository = bookingRepository;
    }

    public void CompletePayment(Guid bookingId, decimal amount)
    {
        var booking = _bookingRepository.GetBookingById(bookingId);
        if (booking == null)
            throw new ArgumentException("Booking not found");

        var payment = new Payment(Guid.NewGuid(), booking.BookingId, amount);
        payment.CompletePayment();
        _paymentRepository.Add(payment);
    }
}