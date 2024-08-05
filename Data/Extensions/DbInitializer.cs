using BusTicketSystem.Models;

namespace BusTicketSystem.Data.Extensions;

public static class DbInitializer
{
    public static void Initialize(TicketSystemContext context)
    {
        if (context.Buses.Any()
        && context.Routes.Any()
        && context.Stops.Any()
        && context.Edges.Any())
        {
            return; //DB has been seeded
        }
        // Stops for long range buses from Sweden to Macedonia, Albania, Kosovo
        var stops = new List<Stop>
        {
            new () {Name = "Stockholm", Latitude = 59.3293, Longitude = 18.0686},
            new () {Name = "Copenhagen", Latitude = 55.6761, Longitude = 12.5683},
            new () {Name = "Hamburg", Latitude = 53.5511, Longitude = 9.9937},
            new () {Name = "Munich", Latitude = 48.1351, Longitude = 11.5820},
            new () {Name = "Vienna", Latitude = 48.2082, Longitude = 16.3738},
            new () {Name = "Ljubljana", Latitude = 46.0569, Longitude = 14.5058},
            new () {Name = "Zagreb", Latitude = 45.8150, Longitude = 15.9819},
            new () {Name = "Belgrade", Latitude = 44.7866, Longitude = 20.4489},
            new () {Name = "Skopje", Latitude = 41.9973, Longitude = 21.4280},
            new () {Name = "Tirana", Latitude = 41.3275, Longitude = 19.8187},
            new () {Name = "Prishtina", Latitude = 42.6629, Longitude = 21.1655}
        };

        context.AddRange(stops);

        var edges = new Edge[]
        {
            new (){Start = stops[0], End = stops[1]},
            new (){Start = stops[1], End = stops[2]},
            new (){Start = stops[2], End = stops[3]},
            new (){Start = stops[3], End = stops[4]},
            new (){Start = stops[4], End = stops[5]},
            new (){Start = stops[5], End = stops[6]},
            new (){Start = stops[6], End = stops[7]},
            new (){Start = stops[7], End = stops[8]},
            new (){Start = stops[8], End = stops[9]},
            new (){Start = stops[9], End = stops[10]}
        };

        context.AddRange(edges);

        var routes = new Models.Route[]
        {
            new () {
                Name = "Sweden - Macedonia",
                Stops = []},
            new () {
                Name = "Sweden - Kosovo",
                Stops = [stops[0], stops[1], stops[2], stops[3], stops[4], stops[5], stops[6], stops[7], stops[8], stops[9], stops[10]]}
        };

        context.AddRange(routes);

        var buses = new Bus[]
        {
            new () {Capacity = 40, Model = "Volvo", Routes = [routes[0]]},
            new () {Capacity = 30, Model = "Mercedes", Routes = [routes[1]]}
        };
        context.AddRange(buses);
        context.SaveChanges();


    }
}