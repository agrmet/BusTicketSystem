using BusTicketSystem.Data;
using BusTicketSystem.Models;

namespace BusTicketSystem.Services;

public class StopService(TicketSystemContext context)
{
    TicketSystemContext _context = context;

    public IEnumerable<Models.Stop> GetAll()
    {
        return _context.Stops;
    }

    public Stop? Get(int id)
    {
        return _context.Stops.Find(id);
    }

    public Stop Create(Stop newStop)
    {
        _context.Stops.Add(newStop);
        _context.SaveChanges();
        return newStop;
    }

    public void Update(Stop stop)
    {
        _context.Stops.Update(stop);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Console.WriteLine("Deleting stop with id: " + id);
        var stop = _context.Stops.Find(id);
        if (stop is not null)
        {
            _context.Stops.Remove(stop);
            _context.SaveChanges();
        }
    }
}