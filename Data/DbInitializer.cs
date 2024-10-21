using Microsoft.EntityFrameworkCore;
using SW4BADAssignment2.Data;
using SW4BADAssignment2.Models;
using System;
using System.Linq;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        // Check if the database is already seeded
        if (context.Cooks.Any())
        {
            return;   // DB has been seeded
        }

        // Seed Kitchens
        var kitchens = new Kitchen[]
        {
            new() { Name = "Noah's Kitchen", Address = "Finlandsgade 17, 8200 Aarhus N" },
            new() { Name = "Helle's Kitchen", Address = "Ny Munkegade 5, 8200 Aarhus N" }
        };
        foreach (var kitchen in kitchens)
        {
            context.Kitchens.Add(kitchen);
        }
        context.SaveChanges();

        // Seed Cooks
        var cooks = new Cook[]
        {
            new() { Name = "Noah", PhoneNumber = "+45 71555080"},
            new() { Name = "Helle", PhoneNumber = "+45 71991234"}
        };
        foreach (var cook in cooks)
        {
            context.Cooks.Add(cook);
        }
        context.SaveChanges();

        // Seed Dishes
        var dishes = new Dish[]
        {
            new() { Name = "Pasta", Price = 30, Quantity = 3},
            new() { Name = "Romkugle", Price = 3, Quantity = 10},
            new() { Name = "Lemonade", Price = 5, Quantity = 2}
        };
        foreach (var dish in dishes)
        {
            context.Dishes.Add(dish);
        }
        context.SaveChanges();

        // Seed Customers
        var customers = new Customer[]
        {
            new() { Name = "Knuth", PhoneNumber = "+45 71992345", Address = "Vejlby Ringvej 1, 8200 Aarhus N" },
            new() { Name = "Alice", PhoneNumber = "+45 71239876", Address = "Finsensgade 1493, 8000 Aarhus" }
        };
        foreach (var customer in customers)
        {
            context.Customers.Add(customer);
        }
        context.SaveChanges();

        // Seed Cyclists
        var cyclists = new Cyclist[]
        {
            new() { Name = "Star", PhoneNumber = "+45 71998765", BikeType = "Mountain" }
        };
        foreach (var cyclist in cyclists)
        {
            context.Cyclists.Add(cyclist);
        }
        context.SaveChanges();

        // Seed Orders with Trips
        var orders = new Order[]
        {
            new() { CookRating = 5, CyclistRating = 4, Customer = customers[0] }
        };
        foreach (var order in orders)
        {
            context.Orders.Add(order);
        }
        context.SaveChanges();
        
        // Seed Trips
        var trips = new Trip[]
        {
            new() { Cyclist = cyclists[0], Order = orders[0]} // Add appropriate properties if there are more
        };
        foreach (var trip in trips)
        {
            context.Trips.Add(trip);
        }
        context.SaveChanges();
        
        // Seed Cook Dish Kitchen
        var cookDishKitchens = new CookDishKitchen[]
        {
            new() { Cook = cooks[0], Dish = dishes[0], Kitchen = kitchens[0] },
            new() { Cook = cooks[0], Dish = dishes[1], Kitchen = kitchens[0] },
            new() { Cook = cooks[1], Dish = dishes[2], Kitchen = kitchens[1] }
        };
        foreach (var cookDishKitchen in cookDishKitchens)
        {
            context.CookDishKitchens.Add(cookDishKitchen);
        }
        context.SaveChanges();
        
        // Seed Dish Order
        var dishOrders = new DishOrder[]
        {
            new() { Quantity = 1, Dish = dishes[0], Order = orders[0] },
            new() { Quantity = 1, Dish = dishes[1], Order = orders[0] }
        };
        foreach (var dishOrder in dishOrders)
        {
            context.DishOrders.Add(dishOrder);
        }
        context.SaveChanges();
    }
}
