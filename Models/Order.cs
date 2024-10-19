namespace SW4BADAssignment2.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int CookRating { get; set; }
        public int CyclistRating { get; set; }

        // Remove foreign key relationships for now
        // public int CookId { get; set; }
        // public Cook Cook { get; set; }

        // public int DishId { get; set; }
        // public Dish Dish { get; set; }
    }

}
