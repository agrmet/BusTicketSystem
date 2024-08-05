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
        .Include(r => r.Stops)
        .AsNoTracking();
    }
    public Models.Route? Get(int id)
    {
        return _context.Routes
        .Include(r => r.Stops)
        .AsNoTracking()
        .SingleOrDefault(r => r.Id == id);

    }
    public Models.Route Create(Models.Route newRoute)
    {
        if (newRoute.Stops?.Count < 2)
        {
            throw new InvalidOperationException("Route must have at least two stops.");
        }
        if (newRoute.Stops is null)
        {
            throw new ArgumentNullException("Route must have stops.");
        }

        newRoute.ConstructEdgesFromStops();
        _context.Routes.Add(newRoute);
        _context.SaveChanges();
        return newRoute;
    }
    public void Update(Models.Route route)
    {
        if (route.Stops is null)
        {
            throw new ArgumentNullException("route", "Route must have stops.");
        }
        if (route.Stops.Count >= 2)
        {
            route.ConstructEdgesFromStops();
        }
        _context.Routes.Update(route);
        _context.SaveChanges();
    }
    public void Delete(int id)
    {
        var route = _context.Routes
        .Include(r => r.Stops)
        .SingleOrDefault(r => r.Id == id);

        if (route is not null)
        {
            if (route.Stops is not null)
            {
                route.Stops.Clear();
            }
            _context.Routes.Update(route);
            _context.Routes.Remove(route);
            _context.SaveChanges();
            return;
        }
    }
    public List<Stop>? AddStop(int id, int stopId)
    {
        var route = _context.Routes.Find(id);

        if (route is null)
        {
            throw new InvalidOperationException("Route not found.");
        }

        var stop = _context.Stops.Find(stopId);
        if (stop is null)
        {
            throw new InvalidOperationException("Stop not found.");
        }

        route.AddStop(stop);
        Update(route);
        return route.Stops;
    }
    public List<Stop>? RemoveStop(int id, int stopId)
    {
        var route = _context.Routes.Find(id);
        if (route is null)
        {
            throw new InvalidOperationException("Route not found.");
        }
        var stop = _context.Stops.Find(stopId);
        if (stop is null)
        {
            throw new InvalidOperationException("Stop not found.");
        }

        route.RemoveStop(stop);
        _context.Routes.Update(route);
        _context.SaveChanges();
        return route.Stops;
    }
}