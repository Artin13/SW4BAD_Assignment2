using Microsoft.EntityFrameworkCore;
using SW4BADAssignment2.Data;
using SW4BADAssignment2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW4BADAssignment2.Services;
public class CookService
{
    private readonly AppDbContext _context;

    public CookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cook>> GetAllAsync() => await _context.Cooks.ToListAsync();

    public async Task<Cook?> GetAsync(int id) => await _context.Cooks.FindAsync(id);

    public async Task AddAsync(Cook cook)
    {
        _context.Cooks.Add(cook);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cook = await _context.Cooks.FindAsync(id);
        if (cook == null) return false;

        _context.Cooks.Remove(cook);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Cook updatedCook)
    {
        var cook = await _context.Cooks.FindAsync(updatedCook.CookId);
        if (cook == null) return false;

        _context.Entry(cook).CurrentValues.SetValues(updatedCook);
        await _context.SaveChangesAsync();
        return true;
    }
}
