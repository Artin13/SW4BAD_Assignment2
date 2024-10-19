using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SW4BADAssignment2.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int Quantity { get; set; }

        [Range(0, 5)]
        public int CookRating { get; set; }

        [Range(0, 5)]
        public int CyclistRating { get; set; }

        // Relationships
        public int CustomerId { get; set; }
        public virtual required Customer Customer { get; set; }
        public int CyclistId { get; set; }
        public virtual required Cyclist Cyclist { get; set; }
        public int TripId { get; set; }
        public virtual required Trip Trip { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; } = new HashSet<Dish>();
    }
}
