using Microsoft.EntityFrameworkCore;
using SW4BADAssignment2.Data;
using SW4BADAssignment2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW4BADAssignment2.Services;
public class OrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetAllAsync() => await _context.Orders.ToListAsync();

    public async Task<Order?> GetAsync(int id) => await _context.Orders.FindAsync(id);

    public async Task AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Order updatedOrder)
    {
        var order = await _context.Orders.FindAsync(updatedOrder.OrderId);
        if (order == null) return false;

        _context.Entry(order).CurrentValues.SetValues(updatedOrder);
        await _context.SaveChangesAsync();
        return true;
    }
}
