using Microsoft.EntityFrameworkCore;
using SW4BADAssignment2.Data;
using SW4BADAssignment2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW4BADAssignment2.Services;
public class CyclistService
{
    private readonly AppDbContext _context;

    public CyclistService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cyclist>> GetAllAsync() => await _context.Cyclists.ToListAsync();

    public async Task<Cyclist?> GetAsync(int id) => await _context.Cyclists.FindAsync(id);

    public async Task AddAsync(Cyclist cyclist)
    {
        _context.Cyclists.Add(cyclist);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cyclist = await _context.Cyclists.FindAsync(id);
        if (cyclist == null) return false;

        _context.Cyclists.Remove(cyclist);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Cyclist updatedCyclist)
    {
        var cyclist = await _context.Cyclists.FindAsync(updatedCyclist.CyclistId);
        if (cyclist == null) return false;

        _context.Entry(cyclist).CurrentValues.SetValues(updatedCyclist);
        await _context.SaveChangesAsync();
        return true;
    }
}
