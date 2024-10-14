using Domain.Common;

namespace Domain.Invoicing;

public class Invoice
{
    public Guid InvoiceId { get; private set; }
    public Guid BookingId { get; private set; }
    public InvoiceStatus Status { get; private set; }
    public decimal Amount { get; private set; }

    public Invoice(Guid invoiceId, Guid bookingId, decimal amount)
    {
        InvoiceId = invoiceId;
        BookingId = bookingId;
        Amount = amount;
        Status = InvoiceStatus.Pending;
    }

    public void CreateInvoice()
    {
        Status = InvoiceStatus.Created;
        // Raise domain event
        DomainEvents.Raise(new InvoiceCreatedEvent(this));
    }
}