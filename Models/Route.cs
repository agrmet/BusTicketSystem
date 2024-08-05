namespace BusTicketSystem.Models;

public class Route
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Stop>? Stops { get; set; }

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

        Stops.Add(stop);

        var edge = new Edge { Start = Stops[Stops.Count - 2], End = Stops[Stops.Count - 1] };

        Console.WriteLine("Adding stop to route " + Stops.Count);
        return Stops;
    }
    public List<Stop> RemoveStop(Stop stop)
    {
        if (Stops is null)
        {
            throw new InvalidOperationException("Cannot remove a stop from an null list of stops.");
        }
        if (Stops.Count == 0)
        {
            throw new InvalidOperationException("Cannot remove a stop from an empty list of stops.");
        }
        foreach (var stopi in Stops)
        {
            if (stopi.Id == stop.Id)
            {
                Stops.Remove(stopi);
                return Stops;

            }
        }
        throw new InvalidOperationException("The stop you want to remove does not exist in this route.");
    }
    public List<Edge>? ConstructEdgesFromStops()
    {
        if (Stops is null)
        {
            throw new InvalidOperationException("Cannot construct edges from null stops.");
        }

        if (Stops.Count < 2)
        {
            throw new InvalidOperationException("Cannot construct edges from less than two stops.");
        }

        var edges = new List<Edge>();

        for (int i = 0; i < Stops.Count - 1; i++)
        {
            var edge = new Edge { Start = Stops[i], End = Stops[i + 1] };
            edges.Add(edge);
        }

        return edges;
    }
    public bool ContainsStop(Stop stop)
    {
        if (Stops is null)
        {
            return false;
        }
        return Stops.Contains(stop);
    }
}