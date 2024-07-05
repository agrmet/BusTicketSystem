namespace BusTicketSystem.Models;
public class Edge
{
    public Edge() { } // Parameterless constructor
    public int Id { get; set; }
    public Stop? PreviousStop { get; set; }
    public Stop? NextStop { get; set; }

    public Edge(Stop previousStop, Stop nextStop)
    {
        PreviousStop = previousStop;
        NextStop = nextStop;
    }
}