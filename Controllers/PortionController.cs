using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Mvc;
using SW4BADAssignment2.Models;
using SW4BADAssignment2.Services;

namespace SW4BADAssignment2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PortionController : ControllerBase
{
    private readonly DishService _dishService;
    private readonly CookDishKitchenService _cookDishKitchenService;

    public PortionController(DishService dishService, CookDishKitchenService cookDishKitchenService)
    {
        _dishService = dishService;
        _cookDishKitchenService = cookDishKitchenService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dish>>> GetAll()
    {
        return Ok(await _dishService.GetAllAsync());
    }

    [HttpPost("AddDish")]
    public async Task<ActionResult<Dish>> Get(string name, int cookId, int price, int kitchenId, int quantity,
        DateTime timeStart, DateTime timeEnd)
    {
        var dish = new Dish()
        {
            Name = name,
            Price = price,
            Quantity = quantity,
            TimeStart = timeStart,
            TimeEnd = timeEnd
        };
        await _dishService.AddAsync(dish);
        await _cookDishKitchenService.AddAsync(new CookDishKitchen()
        {
            CookId = cookId,
            DishId = dish.DishId,
            KitchenId = kitchenId
        });
        return CreatedAtAction(nameof(Get), dish.DishId);

    }

    [HttpPost("UpdateQuantity")]
    public async Task<ActionResult<Dish>> Update(int dishId, int newQuantity)
    {
        var oldDish = await _dishService.GetAsync(dishId);
        if (oldDish == null)
            return NotFound();
        
        var newDish = oldDish;
        newDish.Quantity = newQuantity;

        await _dishService.UpdateAsync(newDish);
        return Ok(newDish);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _dishService.DeleteAsync(id);
        if (!result)
            return NotFound();

        return Ok("Successfully deleted dish with id " + id);
    }

    
}