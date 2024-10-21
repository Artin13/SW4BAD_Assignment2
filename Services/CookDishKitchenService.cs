using Microsoft.EntityFrameworkCore;
using SW4BADAssignment2.Data;
using SW4BADAssignment2.Models;

namespace SW4BADAssignment2.Services;

public class CookDishKitchenService
{
    private readonly AppDbContext _context;

    public CookDishKitchenService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(CookDishKitchen cdk)
    {
        _context.CookDishKitchens.Add(cdk);
        await _context.SaveChangesAsync();
    }
}