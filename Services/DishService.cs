using Microsoft.EntityFrameworkCore;
using SW4BADAssignment2.Data;
using SW4BADAssignment2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW4BADAssignment2.Services;
public class DishService
{
    private readonly AppDbContext _context;

    public DishService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Dish>> GetAllAsync() => await _context.Dishes.ToListAsync();

    public async Task<Dish?> GetAsync(int id) => await _context.Dishes.FindAsync(id);

    public async Task AddAsync(Dish dish)
    {
        _context.Dishes.Add(dish);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var dish = await _context.Dishes.FindAsync(id);
        if (dish == null) return false;

        _context.Dishes.Remove(dish);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Dish updatedDish)
    {
        var dish = await _context.Dishes.FindAsync(updatedDish.DishId);
        if (dish == null) return false;

        _context.Entry(dish).CurrentValues.SetValues(updatedDish);
        await _context.SaveChangesAsync();
        return true;
    }
}
