using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SW4BADAssignment2.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Range(0, 5)]
        public int CookRating { get; set; }

        [Range(0, 5)]
        public int CyclistRating { get; set; }

        // Relationships
        public int CustomerId { get; set; }
        //public int TripId { get; set; }

        // Navigation properties
        public virtual required Customer Customer { get; set; }
        public Trip Trip { get; set; }
        public virtual ICollection<DishOrder> DishOrder { get; set; }
    }
}
