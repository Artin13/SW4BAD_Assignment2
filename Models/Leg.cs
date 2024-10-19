using System;
using System.ComponentModel.DataAnnotations;

namespace SW4BADAssignment2.Models
{
    public class Leg
    {
        [Key]
        public int LegId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } = string.Empty;

        [Required]
        public DateTime Time { get; set; }

        // Navigation property to Trip
        public int TripId { get; set; }
        public virtual required Trip Trip { get; set; }
    }
}
