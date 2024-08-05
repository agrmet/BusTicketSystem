using BusTicketSystem.Services;
using BusTicketSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class RouteController : ControllerBase
{
    private RouteService _service;
    private GraphService _graphService;

    public RouteController(RouteService routeService, GraphService graphService)
    {
        _service = routeService;
        _graphService = graphService;
    }

    [HttpGet]
    public ActionResult<List<Models.Route>> Get() => _service.GetAll().ToList();

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var route = _service.Get(id);
        if (route is null)
        {
            return NotFound();
        }
        return Ok(route);
    }

    [HttpPost]
    public IActionResult Create(Models.Route route)
    {
        var returnRoute = _service.Create(route);

        return CreatedAtAction(nameof(Get), new { id = route.Id }, route);
    }

    [HttpPut]
    public IActionResult Update(Models.Route route)
    {
        _service.Update(route);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var route = _service.Get(id);
        if (route is null)
        {
            return NotFound();
        }
        _service.Delete(id);
        return NoContent();
    }

    [HttpPost("{id}/stops")]
    public IActionResult AddStop(int id, int stopId)
    {
        var route = _service.Get(id);
        if (route is null)
        {
            return NotFound();
        }
        _service.AddStop(id, stopId);
        return NoContent();
    }

    [HttpDelete("{id}/stops")]
    public IActionResult RemoveStop(int id, int stopId)
    {
        var route = _service.Get(id);
        if (route is null)
        {
            return NotFound();
        }

        _service.RemoveStop(id, stopId);
        return NoContent();
    }
}