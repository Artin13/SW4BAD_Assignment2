using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SW4BADAssignment2.Models
{
    public class Cook
    {
        [Key]
        public int CookId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public bool FoodSafetyCertified { get; set; } = false;

        // Removed for part d
        //[RegularExpression(@"\d{9}")]
        //public string SSN { get; set; } = string.Empty;  // Optional based on requirements, assuming format

        // Navigation properties
        public virtual ICollection<CookDishKitchen> CookDishKitchen { get; set; }
    }
}
