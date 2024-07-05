namespace BusTicketSystem.Models;

public class Route
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Stop>? Stops { get; set; }
    public List<Edge>? Edges { get; set; }

    public bool Equals(Route route)
    {
        return Id == route.Id;
    }
    public List<Stop> AddStop(Stop stop)
    {
        if (Stops == null)
        {
            Stops = [];
        }

        if (Stops.Count < 1)
        {
            Stops.Add(stop);
            return Stops;
        }

        Stop lastStop = Stops.Last();

        // Create edge
        if (Edges == null)
        {
            Edges = [];
        }
        var connectedStops = new Edge(lastStop, stop);

        // Update route
        Edges.Add(connectedStops);
        Stops.Add(stop);
        return Stops;
    }
    public List<Stop> RemoveStop(Stop stop)
    {
        if (Stops is null)
        {
            throw new InvalidOperationException("Cannot remove a stop from an empty route.");
        }
        if (Stops.Count == 0)
        {
            throw new InvalidOperationException("Cannot remove a stop from an empty route.");
        }
        if (!Stops.Exists(s => s.Equals(stop)))
        {
            throw new InvalidOperationException("The stop you want to remove does not exist in this route.");
        }
        Stops.Remove(stop);
        return Stops;
    }
}
