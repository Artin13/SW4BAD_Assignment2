using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SW4BADAssignment2.Models
{
    public class Cyclist
    {
        [Key]
        public int CyclistId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public string BikeType { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal HourlyRate { get; set; }

        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<Trip> Trips { get; set; } = new HashSet<Trip>();
    }
}
