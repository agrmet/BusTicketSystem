using BusTicketSystem.Models;
using BusTicketSystem.Data;

namespace BusTicketSystem.Services;

public class GraphService
{
    private readonly TicketSystemContext _context;
    private Graph _graph;

    public GraphService(TicketSystemContext context)
    {
        _context = context;
        _graph = BuildGraph();
    }

    private Graph BuildGraph()
    {
        var edges = _context.Edges.ToHashSet();
        var stops = _context.Stops.ToHashSet();
        var routes = _context.Routes.ToHashSet();
        var graph = new Graph(stops, edges, routes);

        return graph;
    }

    public bool GraphExists()
    {
        return _graph is not null;
    }

    public void AddEdge(Edge edge)
    {
        _graph.AddEdge(edge);
    }

    public void RemoveEdge(Edge edge)
    {
        _graph.RemoveEdge(edge);
    }

    public void AddNode(Stop node)
    {
        _graph.AddNode(node);
    }

    public void RemoveNode(Stop node)
    {
        _graph.RemoveNode(node);
    }

    public bool ContainsNode(Stop node)
    {
        return _graph.ContainsNode(node);
    }

}