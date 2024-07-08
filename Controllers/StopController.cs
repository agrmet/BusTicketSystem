using BusTicketSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class StopController(StopService stopService) : ControllerBase
{
    private StopService _stopService = stopService;

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_stopService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var stop = _stopService.Get(id);
        if (stop is null)
        {
            return NotFound();
        }
        return Ok(stop);
    }

    [HttpPost]
    public IActionResult Create(Models.Stop stop)
    {
        return Ok(_stopService.Create(stop));
    }

    [HttpPut]
    public IActionResult Update(Models.Stop stop)
    {
        _stopService.Update(stop);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _stopService.Delete(id);
        return Ok();
    }
}