using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;

public class TicketSystemDB : DbContext
{
    public TicketSystemDB(DbContextOptions options) : base(options) { }
    public DbSet<Bus> Buses { get; set; } = null!;
}