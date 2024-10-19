using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SW4BADAssignment2.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        // Relationships
        public int CyclistId { get; set; }
        public virtual required Cyclist Cyclist { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
