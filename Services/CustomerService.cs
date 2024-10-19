using Microsoft.EntityFrameworkCore;
using SW4BADAssignment2.Data;
using SW4BADAssignment2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW4BADAssignment2.Services;
public class CustomerService
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllAsync() => await _context.Customers.ToListAsync();

    public async Task<Customer?> GetAsync(int id) => await _context.Customers.FindAsync(id);

    public async Task AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return false;

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Customer updatedCustomer)
    {
        var customer = await _context.Customers.FindAsync(updatedCustomer.CustomerId);
        if (customer == null) return false;

        _context.Entry(customer).CurrentValues.SetValues(updatedCustomer);
        await _context.SaveChangesAsync();
        return true;
    }
}
