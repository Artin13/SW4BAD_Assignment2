namespace SW4BADAssignment2.Models;

public class DishOrder
{
    public int Quantity { get; set; }
    
    public int DishId { get; set; }
        
    public int OrderId { get; set; }
        
    public Dish? Dish { get; set; }
        
    public Order? Order { get; set; }
}