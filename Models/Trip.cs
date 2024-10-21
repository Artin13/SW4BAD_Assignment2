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

        
        public int OrderId { get; set; }
        // Relationship with Legs
        public Order Order { get; set; }
        public virtual ICollection<Leg> Legs { get; set; } = new List<Leg>();
    }
}
