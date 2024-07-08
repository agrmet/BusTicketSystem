namespace BusTicketSystem.Models
{
    public class Graph(HashSet<Stop> nodes, HashSet<Edge> edges, HashSet<Route> routes)
    {
        public HashSet<Stop> Nodes = nodes;
        public HashSet<Edge> Edges = edges;

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
    }
}