using Domain.Common;

namespace Domain.Payment;

public class PaymentCompletedEvent : IDomainEvent
{
    public Payment Payment { get; }

    public PaymentCompletedEvent(Payment payment)
    {
        Payment = payment;
    }
}