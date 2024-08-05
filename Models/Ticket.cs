using BusTicketSystem.Data.Identity;
namespace BusTicketSystem.Models;

public class Ticket()
{
    public int Id { get; set; }
    public User? Passenger { get; set; }
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