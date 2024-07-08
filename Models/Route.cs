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

        Stops.Add(stop);
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
        if (!Stops.Exists(s => s.Equals(stop)))
        {
            throw new InvalidOperationException("The stop you want to remove does not exist in this route.");
        }
        Stops.Remove(stop);
        return Stops;
    }
    public List<Edge>? RemoveEdge(Edge edge)
    {
        if (Edges is null)
        {
            throw new InvalidOperationException("Cannot remove an edge from an null route.");
        }
        if (Edges.Count == 0)
        {
            throw new InvalidOperationException("Cannot remove an edge from an empty route.");
        }
        if (!Edges.Exists(e => e.Equals(edge)))
        {
            throw new InvalidOperationException("The edge you want to remove does not exist in this route.");
        }
        Edges.Remove(edge);
        return Edges;
    }
    public List<Edge>? AddEdge(Edge edge)
    {
        var start = edge.Start;
        var end = edge.End;

        if (start is null || end is null)
        {
            throw new InvalidOperationException("Cannot add an edge with a null start or end stop.");
        }

        if (Stops is null)
        {
            throw new InvalidOperationException("Cannot add an edge to a route where stops is null.");
        }

        if (!Stops.Contains(start) || !Stops.Contains(end))
        {
            throw new InvalidOperationException("Cannot add an edge that does not connect two stops in this route.");
        }

        if (Edges is null)
        {
            Edges = [];
        }

        if (Edges.Count < 1)
        {
            Edges.Add(edge);
            return Edges;
        }

        Edges.Add(edge);
        return Edges;
    }
}
