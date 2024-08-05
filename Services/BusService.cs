using BusTicketSystem.Models;
using BusTicketSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BusTicketSystem.Services;

public class BusService(TicketSystemContext context)
{
    private readonly TicketSystemContext _context = context;

    public IEnumerable<Bus> GetAll()
    {
        return _context.Buses
            .Include(b => b.Routes)
                .ThenInclude(r => r.Stops)
            .AsNoTracking()
            .ToList();
    }

    public Bus? Get(int id)
    {
        return _context.Buses
        .Include(b => b.Routes)
            .ThenInclude(r => r.Stops)
        .AsNoTracking()
        .SingleOrDefault(b => b.Id == id);

    }

    public Bus? GetWithTracking(int id)
    {
        return _context.Buses
        .Include(b => b.Routes)
            .ThenInclude(r => r.Stops)
        .SingleOrDefault(b => b.Id == id);
    }
    public Bus Create(Bus newBus)
    {
        _context.Buses.Add(newBus);
        _context.SaveChanges();
        return newBus;
    }
    public void Update(Bus bus)
    {
        _context.Buses.Update(bus);
        _context.SaveChanges();
    }
    public void Delete(int id)
    {
        var bus = GetWithTracking(id);
        if (bus is not null)
        {
            bus.Routes?.Clear();
            _context.Update(bus);
            _context.Buses.Remove(bus);
            _context.SaveChanges();
        }
    }
    public List<Models.Route>? AssignRoute(int id, int routeid)
    {
        var bus = _context.Buses.Find(id);

        var route = _context.Routes.Find(routeid);

        if (bus is null || route is null)
        {
            throw new Exception("Bus or Route not found in database.");
        }
        bus.AssignRoute(route);
        Update(bus);
        return bus.Routes;
    }
    public List<Models.Route>? RemoveRoute(int id, int routeid)
    {
        var bus = _context.Buses.Find(id);

        var route = _context.Routes.Find(routeid);

        if (bus is null || route is null)
        {
            throw new Exception("Bus or Route not found in database.");
        }

        bus.RemoveRoute(routeid);
        Update(bus);

        // Return the updated routes collection
        return bus.Routes;
    }
}