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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration for Cook to Kitchen relationship
            modelBuilder.Entity<Cook>()
                .HasOne(k => k.Kitchen)
                .WithMany(c => c.Cooks)
                .HasForeignKey(k => k.KitchenId);

            // Configuration for Order relationships
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);  // For simplicity we just set it so the relationships dont need cascading deletes

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Cyclist)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CyclistId)
                .OnDelete(DeleteBehavior.NoAction); // For simplicity we just set it so the relationships dont need cascading deletes

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Trip)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TripId)
                .OnDelete(DeleteBehavior.NoAction); // For simplicity we just set it so the relationships dont need cascading deletes

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
                .OnDelete(DeleteBehavior.NoAction); // For simplicity we just set it so the relationships dont need cascading deletes

            // Optionally you could add configuration for Dish to Cook relationship if needed
            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Cook)
                .WithMany(c => c.Dishes)
                .HasForeignKey(d => d.CookId);

            modelBuilder.Entity<Cyclist>()
                .Property(c => c.HourlyRate)
                .HasColumnType("decimal(18,2)");  // Specifies the precision (18) and scale (2)
        }
    }
}
