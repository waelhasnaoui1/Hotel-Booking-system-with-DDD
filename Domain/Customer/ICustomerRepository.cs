namespace Domain.Customer;

public interface ICustomerRepository
{
    Customer GetCustomerById(Guid customerId);

    void Add(Customer customer);
    Task<Customer> GetByIdAsync(Guid customerId);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(Guid customerId);
    // Additional methods as needed
}