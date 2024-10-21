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
        [StringLength(50)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Address { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string PaymentOption { get; set; } = string.Empty;
        
        [StringLength(16)]
        public string CardInfo { get; set; } = string.Empty;

        // Navigation properties
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
