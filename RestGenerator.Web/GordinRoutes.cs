using System.Collections.Generic;
namespace RestGenerator.Web
{
    internal class GordinRoutes
    {
        public static List<Route> ActiveRoutes { get; set; }
    }

    internal class Route
    {
        public string ApiName { get; set; }
        public string ResourceName { get; set; }
    }
}