using Microsoft.AspNetCore.Mvc;
using SW4BADAssignment2.Models;
using SW4BADAssignment2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW4BADAssignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly TripService _tripService;

        public TripController(TripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetAll()
        {
            return Ok(await _tripService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> Get(int id)
        {
            var trip = await _tripService.GetAsync(id);
            if (trip == null)
                return NotFound();
            return trip;
        }

        [HttpPost]
        public async Task<ActionResult<Trip>> Create(Trip trip)
        {
            await _tripService.AddAsync(trip);
            return CreatedAtAction(nameof(Get), new { id = trip.TripId }, trip);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Trip trip)
        {
            if (id != trip.TripId)
                return BadRequest();

            var result = await _tripService.UpdateAsync(trip);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tripService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
