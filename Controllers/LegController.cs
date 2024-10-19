using Microsoft.AspNetCore.Mvc;
using SW4BADAssignment2.Models;
using SW4BADAssignment2.Services;

[ApiController]
[Route("[controller]")]
public class LegController : ControllerBase
{
    private readonly LegService _legService;

    public LegController(LegService legService)
    {
        _legService = legService;
    }

    [HttpGet]
    public IActionResult GetAllLegs()
    {
        var legs = _legService.GetAllLegs();
        return Ok(legs);
    }

    [HttpGet("{id}")]
    public IActionResult GetLegById(int id)
    {
        var leg = _legService.GetLegById(id);
        if (leg != null)
        {
            return Ok(leg);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult CreateLeg([FromBody] Leg leg)
    {
        var newLeg = _legService.AddLeg(leg);
        return CreatedAtAction(nameof(GetLegById), new { id = newLeg.LegId }, newLeg);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateLeg(int id, [FromBody] Leg leg)
    {
        if (id != leg.LegId)
        {
            return BadRequest();
        }

        var updatedLeg = _legService.UpdateLeg(leg);
        if (updatedLeg == null)
        {
            return NotFound();
        }
        return Ok(updatedLeg);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteLeg(int id)
    {
        _legService.DeleteLeg(id);
        return NoContent();
    }
}
