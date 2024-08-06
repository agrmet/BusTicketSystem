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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the many-to-many relationship between Route and Stop
        modelBuilder.Entity<Models.Route>()
            .HasMany(r => r.Stops)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                    "RouteStop",
                    j => j.HasOne<Stop>().WithMany().HasForeignKey("StopId"),
                    j => j.HasOne<Models.Route>().WithMany().HasForeignKey("RouteId")
                );

        modelBuilder.Entity<Bus>()
        .HasMany(b => b.Routes)
        .WithMany()
        .UsingEntity<Dictionary<string, object>>(
            "BusRoute",
            j => j.HasOne<Models.Route>().WithMany().HasForeignKey("RouteId"),
            j => j.HasOne<Bus>().WithMany().HasForeignKey("BusId")
        );
    }
}