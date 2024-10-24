using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SW4BADAssignment2.Models
{
    public class Kitchen
    {
        [Key]
        public int KitchenId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        // Relationships
        public virtual ICollection<Cook> Cooks { get; set; } = new HashSet<Cook>();
    }
}
