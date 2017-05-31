using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class NavigationManager
{
    public struct Route
    {
        public string RouteDescripton;
        public bool CanTravel;
    }

    public static Dictionary<string, Route> RouteInformation = new Dictionary<string, Route>()
    {
        {"Battle", new Route { CanTravel = true} },
        {"World", new Route { RouteDescripton = "The big bad world", CanTravel = true}},
        {"Cave", new Route {RouteDescripton = "The deep dark cave", CanTravel = false} },
        {"Home", new Route { RouteDescripton = "Home sweet home", CanTravel = true}},
        {"Kirkidw", new Route {RouteDescripton = "The grand city of Kirkidw", CanTravel = true} },
    };

    public static string GetRouteInfo(string destination)
    {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].RouteDescripton : null;
    }

    public static bool CanNavigate(string destination)
    {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].CanTravel : false;
    }

    public static void NavigateTo(string destination)
    {

        if (destination == "Home")
        {
            GameState.PlayerReturningHome = false;
        }
        FadeInOutManager.FadeToLevel(destination);
    }
}
