namespace BusTicketSystem.Models;

public class Route
{
    public int Id { get; set; }
    public string? Name { get; set; }
    private List<Stop> Stops = new List<Stop> { };
    private List<ValueTuple<Stop, Stop, int>> Edges = new List<ValueTuple<Stop, Stop, int>> { };

    public bool Equals(Route route)
    {
        return Id == route.Id;
    }
}