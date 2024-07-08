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
    public List<Route> RemoveRoute(Route route)
    {
        ArgumentNullException.ThrowIfNull(route);
        if (Routes == null)
        {
            throw new InvalidOperationException("This bus has no routes");
        }
        if (!Routes.Contains(route))
        {
            throw new InvalidOperationException("This route is not assigned to the bus");
        }

        foreach (var routei in Routes)
        {
            if (routei.Equals(route))
            {
                Routes.Remove(routei);
                break;
            }
        }
        return Routes;
    }
}