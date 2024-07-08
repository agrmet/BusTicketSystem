using BusTicketSystem.Models;
using BusTicketSystem.Data;

namespace BusTicketSystem.Services;

public class GraphService(TicketSystemContext context)
{
    private readonly TicketSystemContext _context = context;

    public Graph BuildGraph()
    {
        var edges = _context.Edges.ToHashSet();
        var stops = _context.Stops.ToHashSet();
        var routes = _context.Routes.ToHashSet();
        var graph = new Graph(stops, edges, routes);

        return graph;
    }
}