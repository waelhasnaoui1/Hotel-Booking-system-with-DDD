using Domain.Common;

namespace Domain.Invoicing;

public class InvoiceCreatedEvent : IDomainEvent
{
    public Invoice Invoice { get; }

    public InvoiceCreatedEvent(Invoice invoice)
    {
        Invoice = invoice;
    }
}