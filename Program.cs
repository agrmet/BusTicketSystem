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
builder.Services.AddScoped<RouteService>();
builder.Services.AddScoped<StopService>();
builder.Services.AddScoped<GraphService>();

var app = builder.Build();

// Verify that GraphService exists and can build a graph
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var graphService = services.GetRequiredService<GraphService>();
    if (graphService is not null)
    {
        if (!graphService.GraphExists()) throw new Exception("Graph is null.");
    }
    else
    {
        throw new ArgumentNullException("GraphService does not exist.");
    }
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

app.Run();
