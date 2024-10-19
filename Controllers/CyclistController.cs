using Microsoft.AspNetCore.Mvc;
using SW4BADAssignment2.Models;
using SW4BADAssignment2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW4BADAssignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CyclistController : ControllerBase
    {
        private readonly CyclistService _cyclistService;

        public CyclistController(CyclistService cyclistService)
        {
            _cyclistService = cyclistService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cyclist>>> GetAll()
        {
            return Ok(await _cyclistService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cyclist>> Get(int id)
        {
            var cyclist = await _cyclistService.GetAsync(id);
            if (cyclist == null)
                return NotFound();
            return cyclist;
        }

        [HttpPost]
        public async Task<ActionResult<Cyclist>> Create(Cyclist cyclist)
        {
            await _cyclistService.AddAsync(cyclist);
            return CreatedAtAction(nameof(Get), new { id = cyclist.CyclistId }, cyclist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cyclist cyclist)
        {
            if (id != cyclist.CyclistId)
                return BadRequest();

            var result = await _cyclistService.UpdateAsync(cyclist);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cyclistService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
