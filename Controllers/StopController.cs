using BusTicketSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class StopController(StopService stopService) : ControllerBase
{
    private StopService _service = stopService;

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var stop = _service.Get(id);
        if (stop is null)
        {
            return NotFound();
        }
        return Ok(stop);
    }

    [HttpPost]
    public IActionResult Create(Models.Stop stop)
    {
        return Ok(_service.Create(stop));
    }

    [HttpPut]
    public IActionResult Update(Models.Stop stop)
    {
        _service.Update(stop);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok();
    }
}