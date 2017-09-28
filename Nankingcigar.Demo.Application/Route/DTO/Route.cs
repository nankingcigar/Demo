﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
