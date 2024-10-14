using Domain.Payment;

namespace Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _context;

    public PaymentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Payment GetPaymentById(Guid paymentId)
    {
        return _context.Payments.Find(paymentId); // Retrieves a payment by its ID
    }

    public void Add(Payment payment)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment); // Adds the payment to the context asynchronously
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync(); // Saves changes asynchronously
    }
}