using BusTicketSystem.Models;
using BusTicketSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BusTicketSystem.Services;

public class BusService(TicketSystemContext context)
{
    private readonly TicketSystemContext _context = context;

    // CRUD Operations

    public IEnumerable<Bus> GetAll()
    {
        return _context.Buses
        .AsNoTracking();
    }

}