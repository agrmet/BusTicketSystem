using BusTicketSystem.Models;
using BusTicketSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class BusController(BusService service) : ControllerBase
{

    private readonly BusService _service = service;

    [HttpGet]
    public ActionResult<List<Bus>> GetAll() =>
    _service.GetAll().ToList();
}