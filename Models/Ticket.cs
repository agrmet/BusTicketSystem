namespace BusTicketSystem.Models;

public class Ticket()
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Stop? Start { get; set; }
    public Stop? Destination { get; set; }
    public TicketStatus Status { get; set; }
}

public enum TicketStatus
{
    Created,
    Booked,
    Cancelled,
    Finished
}