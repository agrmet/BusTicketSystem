namespace BusTicketSystem.Models;
public class Graph(HashSet<Stop> nodes, HashSet<Edge> edges, HashSet<Route> routes)
{
    public HashSet<Stop> Nodes { get; } = nodes;
    public HashSet<Edge> Edges { get; } = edges;

    public Dictionary<Edge, List<int>> EdgeRouteMap = MapEdgesToRoutes(routes);

    private static Dictionary<Edge, List<int>> MapEdgesToRoutes(HashSet<Route> routes)
    {
        Dictionary<Edge, List<int>> edgeRouteMap = [];
        foreach (Route route in routes)
        {
            var edges = route.ConstructEdgesFromStops();
            if (edges == null) continue;
            foreach (Edge edge in edges)
            {
                if (edgeRouteMap.TryGetValue(edge, out List<int>? value))
                {
                    if (value.Contains(route.Id)) continue;
                    value.Add(route.Id);
                }
                else
                {
                    edgeRouteMap[edge] = [route.Id];
                }
            }
        }
        return edgeRouteMap;
    }

    public void ExtractEdgesFromRoute(Route route)
    {
        var edges = route.ConstructEdgesFromStops();
        if (edges == null) return;
        foreach (Edge edge in edges)
        {
            AddEdge(edge, route.Id);
        }
    }

    public void RemoveRoute(Route route)
    {
        var edges = route.ConstructEdgesFromStops();
        if (edges == null) return;
        foreach (Edge edge in edges)
        {
            RemoveEdge(edge, route.Id);
        }
    }

    public void AddEdge(Edge edge, int routeId)
    {
        if (EdgeRouteMap.TryGetValue(edge, out List<int>? value))
        {
            if (value.Contains(routeId)) return;
            value.Add(routeId);
        }
        else
        {
            EdgeRouteMap[edge] = [routeId];
        }
        Edges.Add(edge);
    }

    public void RemoveEdge(Edge edge, int routeId)
    {
        if (!Edges.Contains(edge)) throw new InvalidOperationException("Edge does not exist in the graph.");
        Edges.Remove(edge);

        if (EdgeRouteMap.TryGetValue(edge, out List<int>? value))
        {
            if (value.Count <= 1)
            {
                EdgeRouteMap.Remove(edge);
                Edges.Remove(edge);
                return;
            }
            value.Remove(routeId);
            EdgeRouteMap.Remove(edge);
        }
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
