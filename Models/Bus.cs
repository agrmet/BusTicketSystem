namespace BusTicketSystem.Models;

public class Bus : Vehicle
{
    public List<Route>? Routes { get; set; }

    public List<Route> AssignRoute(Route route)
    {
        if (Routes == null)
        {
            Routes = [route];
        }
        else
        {
            Routes.Add(route);
        }
        return Routes;
    }
    public List<Route> RemoveRoute(int routeId)
    {
        ArgumentNullException.ThrowIfNull(routeId);
        if (Routes == null)
        {
            throw new InvalidOperationException("This bus has no routes");
        }
        foreach (Models.Route route in Routes)
        {
            if (route.Id == routeId)
            {
                Routes.Remove(route);
                return Routes;
            }
        }
        throw new InvalidOperationException("This bus does not have this route");
    }
}