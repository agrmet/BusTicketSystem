namespace BusTicketSystem.Models;
public class Graph(HashSet<Stop> nodes, HashSet<Edge> edges, HashSet<Route> routes)
{
    public HashSet<Stop> Nodes { get; } = nodes;
    public HashSet<Edge> Edges { get; } = edges;

    public Dictionary<Edge, int> EdgeRouteMap = MapEdgesToRoutes(edges, routes);

    private static Dictionary<Edge, int> MapEdgesToRoutes(HashSet<Edge> edges, HashSet<Route> routes)
    {
        Dictionary<Edge, int> edgeRouteMap = [];
        foreach (Edge edge in edges)
        {
            foreach (Route route in routes)
            {
                if (route.Edges is null) continue;
                if (route.Edges.Contains(edge))
                {
                    edgeRouteMap.Add(edge, route.Id);
                }
            }
        }
        return edgeRouteMap;
    }

    public void AddEdge(Edge edge)
    {
        if (Edges.Contains(edge)) return;
        Edges.Add(edge);
    }

    public void RemoveEdge(Edge edge)
    {
        if (!Edges.Contains(edge)) return;
        Edges.Remove(edge);
    }

    public void AddNode(Stop node)
    {
        if (Nodes.Contains(node)) return;
        Nodes.Add(node);
    }

    public void RemoveNode(Stop node)
    {
        if (!Nodes.Contains(node)) return;
        Nodes.Remove(node);
    }

    public bool ContainsNode(Stop node)
    {
        return Nodes.Contains(node);
    }
    /*  Returns a list of tuples where the first element is the routeid and the second element is a list of 
    stops which are taken on that route.*/
    public List<Tuple<int, List<Stop>>> FindPath(Stop start, Stop end)
    {
        throw new NotImplementedException();
    }
}
