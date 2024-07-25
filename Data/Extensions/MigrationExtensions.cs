using BusTicketSystem.Data.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusTicketSystem.Data.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using UserDbContext usercontext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
        using TicketSystemContext context = scope.ServiceProvider.GetRequiredService<TicketSystemContext>();
        context.Database.Migrate();
        usercontext.Database.Migrate();
    }
}