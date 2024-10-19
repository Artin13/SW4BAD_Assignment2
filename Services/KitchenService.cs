using SW4BADAssignment2.Data;
using SW4BADAssignment2.Models;
using System.Collections.Generic;
using System.Linq;

public class KitchenService
{
    private readonly AppDbContext _context;

    public KitchenService(AppDbContext context)
    {
        _context = context;
    }

    public List<Kitchen> GetAllKitchens()
    {
        return _context.Kitchens.ToList();
    }

    public Kitchen? GetKitchenById(int id)
    {
        if(_context.Kitchens.FirstOrDefault(k => k.KitchenId == id) == null)
        {
            return null;
        }
        return _context.Kitchens.FirstOrDefault(k => k.KitchenId == id);
    }

    public Kitchen AddKitchen(Kitchen kitchen)
    {
        _context.Kitchens.Add(kitchen);
        _context.SaveChanges();
        return kitchen;
    }

public Kitchen? UpdateKitchen(Kitchen kitchen)
{
    var existingKitchen = _context.Kitchens.Find(kitchen.KitchenId);
    if (existingKitchen == null)
    {
        return null; 
    }
    existingKitchen.Name = kitchen.Name;
    existingKitchen.Address = kitchen.Address;
    _context.SaveChanges();
    return existingKitchen;
}


    public void DeleteKitchen(int id)
    {
        var kitchen = _context.Kitchens.Find(id);
        if (kitchen != null)
        {
            _context.Kitchens.Remove(kitchen);
            _context.SaveChanges();
        }
    }
}
