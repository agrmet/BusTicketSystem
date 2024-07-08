using BusTicketSystem.Models;
using BusTicketSystem.Data;

namespace BusTicketSystem.Services;

public class GraphService
{
    private readonly TicketSystemContext _context;
    private Graph _graph { get; set; } = null!;

    public GraphService(TicketSystemContext context)
    {
        _context = context;
        _graph = BuildGraph();
    }

    public Graph BuildGraph()
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
}