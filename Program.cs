using BusTicketSystem.Models;
using BusTicketSystem.Data;
using BusTicketSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BusTicketSystem.Data.Identity;
using BusTicketSystem.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TicketSystem");

// Add auth and identity services
builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddApiEndpoints();

// Add database services
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Users")));
builder.Services.AddDbContext<TicketSystemContext>(options =>
    options.UseSqlite(connectionString));

// Adding website services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding custom services
builder.Services.AddSingleton<GraphService>();
builder.Services.AddScoped<BusService>();
builder.Services.AddScoped<RouteService>();
builder.Services.AddScoped<StopService>();

var app = builder.Build();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.CreateDbIfNotExists();

app.MapIdentityApi<User>();

app.Run();
