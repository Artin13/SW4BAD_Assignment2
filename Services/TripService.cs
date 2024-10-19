using Microsoft.EntityFrameworkCore;
using SW4BADAssignment2.Data;
using SW4BADAssignment2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW4BADAssignment2.Services;
public class TripService
{
    private readonly AppDbContext _context;

    public TripService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Trip>> GetAllAsync() => await _context.Trips.ToListAsync();

    public async Task<Trip?> GetAsync(int id) => await _context.Trips.FindAsync(id);

    public async Task AddAsync(Trip trip)
    {
        _context.Trips.Add(trip);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var trip = await _context.Trips.FindAsync(id);
        if (trip == null) return false;

        _context.Trips.Remove(trip);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Trip updatedTrip)
    {
        var trip = await _context.Trips.FindAsync(updatedTrip.TripId);
        if (trip == null) return false;

        _context.Entry(trip).CurrentValues.SetValues(updatedTrip);
        await _context.SaveChangesAsync();
        return true;
    }
}
