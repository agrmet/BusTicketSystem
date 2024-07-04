using BusTicketSystem.Models;
using BusTicketSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class BusController(BusService service) : ControllerBase
{
    private readonly BusService _service = service;
    // GET all action
    [HttpGet]
    public ActionResult<List<Bus>> GetAll() =>
    _service.GetAll().ToList();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Bus> Get(int id)
    {
        var bus = _service.Get(id);

        if (bus is null)
        {
            return NotFound();
        }
        return bus;
    }
    // POST action
    [HttpPost]
    public IActionResult Create(Bus bus)
    {
        _service.Create(bus);
        return CreatedAtAction(nameof(Get), new { id = bus.Id }, bus);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Bus bus)
    {
        if (id != bus.Id)
        {
            return BadRequest();
        }
        var existingBus = _service.Get(id);
        if (existingBus is null)
        {
            return NotFound();
        }

        _service.Update(bus);
        return NoContent();
    }

    // DELETE action
    public IActionResult Delete(int id)
    {
        var bus = Get(id);
        if (bus is null)
        {
            return NotFound();
        }
        _service.Delete(id);
        return NoContent();
    }
}