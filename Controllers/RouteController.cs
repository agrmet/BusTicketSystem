using BusTicketSystem.Services;
using BusTicketSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class RouteController(RouteService routeService) : ControllerBase
{
    private RouteService _routeService = routeService;

    [HttpGet]
    public ActionResult<List<Models.Route>> Get() => routeService.GetAll().ToList();

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var route = _routeService.Get(id);
        if (route is null)
        {
            return NotFound();
        }
        return Ok(route);
    }

    [HttpPost]
    public IActionResult Create(Models.Route route)
    {
        return Ok(_routeService.Create(route));
    }

    [HttpPut]
    public IActionResult Update(Models.Route route)
    {
        _routeService.Update(route);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _routeService.Delete(id);
        return Ok();
    }

    [HttpPost("{id}/stops")]
    public IActionResult AddStop(int id, Stop stop)
    {
        var route = _routeService.Get(id);
        if (route is null)
        {
            return NotFound();
        }
        return Ok(_routeService.AddStop(id, stop));
    }

    [HttpDelete("{id}/stops")]
    public IActionResult RemoveStop(int id, Stop stop)
    {
        var route = _routeService.Get(id);
        if (route is null)
        {
            return NotFound();
        }
        return Ok(_routeService.RemoveStop(id, stop));
    }

    [HttpPost("{id}/edges")]
    public IActionResult AddEdge(int id, Edge edge)
    {
        var route = _routeService.Get(id);
        if (route is null)
        {
            return NotFound();
        }
        return Ok(_routeService.AddEdge(id, edge));
    }

    [HttpDelete("{id}/edges")]
    public IActionResult RemoveEdge(int id, Edge edge)
    {
        var route = _routeService.Get(id);
        if (route is null)
        {
            return NotFound();
        }
        return Ok(_routeService.RemoveEdge(id, edge));
    }
}