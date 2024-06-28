namespace BusTicketSystem.Models;

public class Stop
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Tuple<double, double>? Location;
}