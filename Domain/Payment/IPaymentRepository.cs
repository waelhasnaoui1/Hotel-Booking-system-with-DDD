namespace Domain.Payment;

public interface IPaymentRepository
{
    Payment GetPaymentById(Guid paymentId);
    void Add(Payment payment);
    Task AddAsync(Payment payment); // Added asynchronous method for adding a payment
    Task SaveChangesAsync();
    
}