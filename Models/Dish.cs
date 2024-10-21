using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SW4BADAssignment2.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        public int Quantity { get; set; }

        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        // Navigation properties
        public virtual ICollection<CookDishKitchen> CookDishKitchen { get; set; }
        public virtual ICollection<DishOrder> DishOrder { get; set; }
    }
}
