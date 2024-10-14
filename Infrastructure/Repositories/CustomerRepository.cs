﻿using Domain.Customer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;


public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Customer GetCustomerById(Guid customerId)
    {
        return _context.Customers.Find(customerId);
    }

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }
    
    public async Task<Customer> GetByIdAsync(Guid customerId)
    {
        return await _context.Customers.FindAsync(customerId);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid customerId)
    {
        var customer = await GetByIdAsync(customerId);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}