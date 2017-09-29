using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Nankingcigar.Demo.Application.Route.DTO
{
    public class Route
    {
        public string Path { get; set; }
    }

    public class ModuleRoute : Route
    {
        public string LoadChildren { get; set; }
    }

    public class ComponentRoute : Route
    {
        public string Component { get; set; }
        public JObject Data { get; set; }
        public ICollection<Route> Children { get; set; }
    }

    public class RedirectRoute : Route
    {
        public string RedirectTo { get; set; }
        public string PathMatch { get; set; }
    }
}