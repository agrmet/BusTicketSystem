namespace BusTicketSystem.Models;

public class Bus : Vehicle
{
    private List<Route>? Routes;

    public List<Route> AssignRoute(Route route)
    {
        if (Routes == null)
        {
            Routes = new List<Route> { route };
        }
        else
        {
            Routes.Add(route);
        }
        return Routes;
    }
    public List<Route> RemoveRoute(Route route)
    {
        if (Routes == null)
        {
            throw new InvalidOperationException("This bus has no routes");
        }
        if (!Routes.Contains(route))
        {
            throw new InvalidOperationException("This route is not assigned to the bus");
        }
        if (route == null)
        {
            throw new ArgumentNullException("The route to be removed cannot be null");
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