using Microsoft.EntityFrameworkCore;
using SW4BADAssignment2.Models;

namespace SW4BADAssignment2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cyclist> Cyclists { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<CookDishKitchen> CookDishKitchens { get; set; }
        public DbSet<DishOrder> DishOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration for Cook Dish Kitchen
            modelBuilder.Entity<CookDishKitchen>()
                .HasKey(cdk => new { cdk.CookId, cdk.DishId, cdk.KitchenId });

            modelBuilder.Entity<CookDishKitchen>()
                .HasOne(cdk => cdk.Cook)
                .WithMany(c => c.CookDishKitchen)
                .HasForeignKey(cdk => cdk.CookId);

            modelBuilder.Entity<CookDishKitchen>()
                .HasOne(cdk => cdk.Dish)
                .WithMany(d => d.CookDishKitchen)
                .HasForeignKey(cdk => cdk.DishId);

            modelBuilder.Entity<CookDishKitchen>()
                .HasOne(cdk => cdk.Kitchen)
                .WithMany(k => k.CookDishKitchen)
                .HasForeignKey(cdk => cdk.KitchenId);

            // Configuration for Dish Order
            modelBuilder.Entity<DishOrder>()
                .HasKey(d => new { d.DishId, d.OrderId });

            modelBuilder.Entity<DishOrder>()
                .HasOne(d => d.Dish)
                .WithMany(d => d.DishOrder)
                .HasForeignKey(d => d.DishId);

            modelBuilder.Entity<DishOrder>()
                .HasOne(d => d.Order)
                .WithMany(o => o.DishOrder)
                .HasForeignKey(o => o.OrderId);

            // Order relationships
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior
                    .NoAction); // For simplicity we just set it so the relationships dont need cascading deletes

            // Configuration for Trip to Cyclist relationship
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Cyclist)
                .WithMany(c => c.Trips)
                .HasForeignKey(t => t.CyclistId);

            // Configuration for Leg to Trip relationship
            modelBuilder.Entity<Leg>()
                .HasOne(l => l.Trip)
                .WithMany(t => t.Legs)
                .HasForeignKey(l => l.TripId)
                .OnDelete(DeleteBehavior
                    .NoAction); // For simplicity we just set it so the relationships dont need cascading deletes

            modelBuilder.Entity<Cyclist>()
                .Property(c => c.HourlyRate)
                .HasColumnType("decimal(18,2)"); // Specifies the precision (18) and scale (2)
        }
    }
}