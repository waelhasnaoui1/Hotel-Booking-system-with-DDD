namespace Domain.Invoicing;

public interface IInvoiceRepository
{
    Invoice GetInvoiceById(Guid invoiceId);
    void Add(Invoice invoice);
}