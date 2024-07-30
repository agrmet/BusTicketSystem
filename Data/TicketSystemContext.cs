using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTicketSystem.Data;
public class TicketSystemContext(DbContextOptions<TicketSystemContext> options) : DbContext(options)
{
    public DbSet<Bus> Buses { get; set; } = null!;
    // 'Route' is an ambiguous reference between 'BusTicketSystem.Models.Route' and 'Microsoft.AspNetCore.Routing.Route'
    public DbSet<Models.Route> Routes { get; set; } = null!;
    public DbSet<Stop> Stops { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;

    public DbSet<Edge> Edges { get; set; } = null!;
}