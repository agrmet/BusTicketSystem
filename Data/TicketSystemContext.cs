using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTicketSystem.Data;
public class TicketSystemContext : DbContext
{
    public TicketSystemContext(DbContextOptions options) : base(options) { }
    public DbSet<Bus> Buses { get; set; } = null!;
}