using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace SW4BADAssignment2.Models
{
    public class CookDishKitchen
    {
        public int CookId { get; set; }
        
        public int DishId { get; set; }
        
        public int KitchenId { get; set; }
        
        public Cook Cook { get; set; }
        
        public Dish Dish { get; set; }
        
        public Kitchen Kitchen { get; set; }
    }
}
