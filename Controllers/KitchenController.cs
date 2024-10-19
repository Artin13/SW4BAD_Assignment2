using Microsoft.AspNetCore.Mvc;
using SW4BADAssignment2.Models;
using SW4BADAssignment2.Services;

[ApiController]
[Route("[controller]")]
public class KitchenController : ControllerBase
{
    private readonly KitchenService _kitchenService;

    public KitchenController(KitchenService kitchenService)
    {
        _kitchenService = kitchenService;
    }

    [HttpGet]
    public IActionResult GetAllKitchens()
    {
        var kitchens = _kitchenService.GetAllKitchens();
        return Ok(kitchens);
    }

    [HttpGet("{id}")]
    public IActionResult GetKitchenById(int id)
    {
        var kitchen = _kitchenService.GetKitchenById(id);
        if (kitchen != null)
        {
            return Ok(kitchen);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult CreateKitchen([FromBody] Kitchen kitchen)
    {
        var newKitchen = _kitchenService.AddKitchen(kitchen);
        return CreatedAtAction(nameof(GetKitchenById), new { id = newKitchen.KitchenId }, newKitchen);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateKitchen(int id, [FromBody] Kitchen kitchen)
    {
        if (id != kitchen.KitchenId)
        {
            return BadRequest();
        }

        var updatedKitchen = _kitchenService.UpdateKitchen(kitchen);
        if (updatedKitchen == null)
        {
            return NotFound();
        }
        return Ok(updatedKitchen);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteKitchen(int id)
    {
        _kitchenService.DeleteKitchen(id);
        return NoContent();
    }
}
