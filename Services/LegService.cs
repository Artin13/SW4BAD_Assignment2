using SW4BADAssignment2.Data;
using SW4BADAssignment2.Models;
using System.Collections.Generic;
using System.Linq;

public class LegService
{
    private readonly AppDbContext _context;

    public LegService(AppDbContext context)
    {
        _context = context;
    }

    public List<Leg> GetAllLegs()
    {
        return _context.Legs.ToList();
    }

    public Leg? GetLegById(int id)
    {
        return _context.Legs.FirstOrDefault(l => l.LegId == id);
    }

    public Leg AddLeg(Leg leg)
    {
        _context.Legs.Add(leg);
        _context.SaveChanges();
        return leg;
    }

    public Leg? UpdateLeg(Leg leg)
    {
        var existingLeg = _context.Legs.Find(leg.LegId);
        if (existingLeg != null)
        {
            existingLeg.Date = leg.Date;
            existingLeg.Time = leg.Time;
            existingLeg.Type = leg.Type;
            existingLeg.TripId = leg.TripId;
            _context.SaveChanges();
        }
        return existingLeg;
    }

    public void DeleteLeg(int id)
    {
        var leg = _context.Legs.Find(id);
        if (leg != null)
        {
            _context.Legs.Remove(leg);
            _context.SaveChanges();
        }
    }
}
