using Domain.Common;

namespace Domain.Payment;

public class Payment
{
    public Guid PaymentId { get;  set; }
    public Guid BookingId { get;  set; }
    public PaymentStatus Status { get;  set; }
    public decimal Amount { get;  set; }

    public Payment(Guid paymentId, Guid bookingId, decimal amount)
    {
        PaymentId = paymentId;
        BookingId = bookingId;
        Amount = amount;
        Status = PaymentStatus.Pending;
    }

    public Payment()
    {
        
    }


    public void CompletePayment()
    {
        Status = PaymentStatus.Completed;
        // Raise domain event
        DomainEvents.Raise(new PaymentCompletedEvent(this));
    }
}