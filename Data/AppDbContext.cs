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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Remove any configuration related to Order foreign keys
            // modelBuilder.Entity<Order>()
            //     .HasOne(o => o.Dish)
            //     .WithMany()
            //     .HasForeignKey(o => o.DishId);

            // modelBuilder.Entity<Order>()
            //     .HasOne(o => o.Cook)
            //     .WithMany()
            //     .HasForeignKey(o => o.CookId);
        }

    }
}
