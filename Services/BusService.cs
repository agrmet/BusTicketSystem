using BusTicketSystem.Models;
using BusTicketSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketSystem.Services;

public class BusService(TicketSystemContext context)
{
    private readonly TicketSystemContext _context = context;

    public IEnumerable<Bus> GetAll()
    {
        return _context.Buses
        .AsNoTracking();
    }
    public Bus? Get(int id)
    {
        return _context.Buses
        .Include(b => b.Id)
        .Include(b => b.Capacity)
        .Include(b => b.Model)
        .Include(b => b.Routes)
        .AsNoTracking()
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
        var bus = _context.Buses.Find(id);
        if (bus is not null)
        {
            _context.Buses.Remove(bus);
            _context.SaveChanges();
        }
    }
    public List<Models.Route>? AssignRoute(int id, Models.Route route)
    {
        var bus = Get(id);

        return bus?.AssignRoute(route);
    }
    public List<Models.Route>? RemoveRoute(int id, Models.Route route)
    {
        var bus = Get(id);

        return bus?.RemoveRoute(route);
    }
}