using Microsoft.AspNetCore.Mvc;
using SW4BADAssignment2.Models;
using SW4BADAssignment2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW4BADAssignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly DishService _dishService;

        public DishController(DishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetAll()
        {
            return Ok(await _dishService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> Get(int id)
        {
            var dish = await _dishService.GetAsync(id);
            if (dish == null)
                return NotFound();
            return dish;
        }

        [HttpPost]
        public async Task<ActionResult<Dish>> Create(Dish dish)
        {
            await _dishService.AddAsync(dish);
            return CreatedAtAction(nameof(Get), new { id = dish.DishId }, dish);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Dish dish)
        {
            if (id != dish.DishId)
                return BadRequest();

            var result = await _dishService.UpdateAsync(dish);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _dishService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
