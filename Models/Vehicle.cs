namespace BusTicketSystem.Models;

public abstract class Vehicle
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public string? Model { get; set; }
}
