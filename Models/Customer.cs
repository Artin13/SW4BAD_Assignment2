using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SW4BADAssignment2.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; }
    }
}
