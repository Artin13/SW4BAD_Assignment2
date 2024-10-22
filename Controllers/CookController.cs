using Microsoft.AspNetCore.Mvc;
using SW4BADAssignment2.Models;
using SW4BADAssignment2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW4BADAssignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookController : ControllerBase
    {
        private readonly CookService _cookService;

        public CookController(CookService cookService)
        {
            _cookService = cookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cook>>> GetAll()
        {
            return Ok(await _cookService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cook>> Get(int id)
        {
            var cook = await _cookService.GetAsync(id);
            if (cook == null)
                return NotFound();
            return cook;
        }

        [HttpPost]
        public async Task<ActionResult<Cook>> Create(string name, string phoneNumber, bool foodSafetyCertified)
        {
            var cook = new Cook
            {
                Name = name,
                PhoneNumber = phoneNumber,
                FoodSafetyCertified = foodSafetyCertified
            };
            await _cookService.AddAsync(cook);
            return CreatedAtAction(nameof(Get), new { id = cook.CookId }, cook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cook cook)
        {
            if (id != cook.CookId)
                return BadRequest();

            var result = await _cookService.UpdateAsync(cook);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cookService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
