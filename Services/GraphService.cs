using BusTicketSystem.Models;
using BusTicketSystem.Data;

namespace BusTicketSystem.Services;

public class GraphService
{
    private readonly TicketSystemContext _context;
    private Graph _graph;

    public GraphService(IServiceProvider serviceProvider)
    {
        Console.WriteLine("GraphService created.");
        using var scope = serviceProvider.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<TicketSystemContext>();
        _graph = BuildGraph();
    }

    public Graph BuildGraph()
    {
        var edges = _context.Edges.ToHashSet();
        var stops = _context.Stops.ToHashSet();
        var routes = _context.Routes.ToHashSet();
        var graph = new Graph(stops, edges, routes);

        Console.WriteLine("Graph built.");
        return graph;
    }

    public bool GraphExists()
    {
        return _graph is not null;
    }

    public void AddEdge(Edge edge, int routeId)
    {
        _graph.AddEdge(edge, routeId);
    }

    public void RemoveEdge(Edge edge, int routeId)
    {
        _graph.RemoveEdge(edge, routeId);
    }

    public void AddNode(int stopId)
    {
        var node = _context.Stops.Find(stopId) ?? throw new InvalidOperationException("Cannot find stop in the database.");
        _graph.AddNode(node);
    }

    public void RemoveNode(int stopId)
    {
        var node = _context.Stops.Find(stopId) ?? throw new InvalidOperationException("Cannot find stop in the database.");
        _graph.RemoveNode(node);
    }

    public bool ContainsNode(int stopId)
    {
        var node = _context.Stops.Find(stopId) ?? throw new InvalidOperationException("Cannot find stop in the database.");
        return _graph.ContainsNode(node);
    }

    public void ExtractEdgesFromRoute(Models.Route route)
    {
        _graph.ExtractEdgesFromRoute(route);
    }

}