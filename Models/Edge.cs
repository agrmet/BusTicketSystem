namespace BusTicketSystem.Models;
public class Edge
{
    public Edge() { } // Parameterless constructor
    public int Id { get; set; }
    public Stop? Start { get; set; }
    public Stop? End { get; set; }

    public Edge(Stop start, Stop end)
    {
        Start = start;
        End = end;
    }
}