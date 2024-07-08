using BusTicketSystem.Models;
using BusTicketSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BusTicketSystem.Services;

public class RouteService(TicketSystemContext context)
{
    private readonly TicketSystemContext _context = context;

    public IEnumerable<Models.Route> GetAll()
    {
        return _context.Routes
        .Include(r => r.Edges)
        .AsNoTracking();
    }
    public Models.Route? Get(int id)
    {
        return _context.Routes
        .Include(r => r.Id)
        .Include(r => r.Name)
        .Include(r => r.Edges)
        .AsNoTracking()
        .SingleOrDefault(r => r.Id == id);

    }
    public Models.Route Create(Models.Route newRoute)
    {
        _context.Routes.Add(newRoute);
        _context.SaveChanges();
        return newRoute;
    }
    public void Update(Models.Route route)
    {
        _context.Routes.Update(route);
        _context.SaveChanges();
    }
    public void Delete(int id)
    {
        var route = _context.Routes.Find(id);
        if (route is not null)
        {
            _context.Routes.Remove(route);
            _context.SaveChanges();
        }
    }
    public List<Edge>? AddEdge(int id, Edge edge)
    {
        var route = Get(id);

        return route?.AddEdge(edge);
    }
    public List<Edge>? RemoveEdge(int id, Edge edge)
    {
        var route = Get(id);

        return route?.RemoveEdge(edge);
    }

    public List<Stop>? AddStop(int id, Stop stop)
    {
        var route = Get(id);

        return route?.AddStop(stop);
    }

    public List<Stop>? RemoveStop(int id, Stop stop)
    {
        var route = Get(id);

        return route?.RemoveStop(stop);
    }
}