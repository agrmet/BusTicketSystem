using BusTicketSystem.Models;
using BusTicketSystem.Data;
using BusTicketSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TicketSystem") ?? "Data Source=TicketSystem.db";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlite<TicketSystemContext>(connectionString);
builder.Services.AddScoped<BusService>();
builder.Services.AddScoped<GraphService>();

var app = builder.Build();

// Verify that GraphService exists and can build a graph
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var graphService = services.GetRequiredService<GraphService>();
    if (graphService is not null)
    {
        Console.WriteLine("GraphService exists.");
        var graph = graphService.BuildGraph();
        if (graph is null) throw new Exception("Graph is null.");
        Console.WriteLine("Graph has been built successfully.");
    }
    else
    {
        throw new ArgumentNullException("GraphService does not exist.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

app.Run();
