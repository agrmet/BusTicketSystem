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
        if (Routes is null)
        {
            throw new InvalidOperationException("This bus does not have any routes");
        }
        foreach (Models.Route routei in Routes)
        {
            if (route.Id == routei.Id)
            {
                Routes.Remove(routei);
                return Routes;
            }
        }
        throw new InvalidOperationException("This bus does not have this route");
    }
}