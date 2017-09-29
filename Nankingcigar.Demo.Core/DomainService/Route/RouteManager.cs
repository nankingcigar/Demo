using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.Core.Entity.POCO.Component;
using Nankingcigar.Demo.Core.Entity.POCO.Module;
using Nankingcigar.Demo.Core.Entity.POCO.Role;
using Nankingcigar.Demo.Core.Entity.POCO.Route;
using Nankingcigar.Demo.Core.Entity.POCO.User;
using Nankingcigar.Demo.Core.Entity.View.Route;
using Nankingcigar.Demo.Core.Extension.Repository.Dapper;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.DomainService.Route
{
    internal class RouteManager : DemoDomainServiceBase, IRouteManager
    {
        public IDapperRepositoryExtension<Module, long> ModuleDapperRepository { get; set; }
        public IDapperRepositoryExtension<ModuleRelationship, long> ModuleRelationshipDapperRepository { get; set; }
        public IDapperRepositoryExtension<Component, long> ComponentDapperRepository { get; set; }
        public IDapperRepositoryExtension<ModuleComponent, long> ModuleComponentDapperRepository { get; set; }
        public IDapperRepositoryExtension<Core.Entity.POCO.Route.Route, long> RouteDapperRepository { get; set; }
        public IDapperRepositoryExtension<RouteRelationship, long> RouteRelationshipDapperRepository { get; set; }
        public IDapperRepositoryExtension<RoleRoute, long> RoleRouteDapperRepository { get; set; }
        public IDapperRepositoryExtension<RoleUser, long> RoleUserDapperRepository { get; set; }
        public IDapperRepositoryExtension<UserRoute, long> UserRouteDapperRepository { get; set; }

        public async Task<IEnumerable<Entity.View.Route.Route>> GetRoutesByModuleAndUser(string moduleName)
        {
            var module = await ModuleDapperRepository.FirstOrDefaultAsync(entity => entity.Name == moduleName);
            CheckModule(module);
            var moduleRelationships = (await ModuleRelationshipDapperRepository.GetAllAsync(entity => entity.ParentId == module.Id)).ToArray();
            var moduleComponents = (await ModuleComponentDapperRepository.GetAllAsync(entity => entity.ModuleId == module.Id)).ToArray();
            IEnumerable<Component> components = new List<Component>();
            var componentIds = moduleComponents.Select(entity => entity.ComponentId);
            if (moduleComponents.Any())
            {
                components = (await ComponentDapperRepository.GetAllAsync()).Where(entity => componentIds.Contains(entity.Id));
            }
            var moduleRelationshipIds = moduleRelationships.Select(entity => entity.Id);
            var moduleComponentIds = moduleComponents.Select(entity => entity.Id);
            var moduleRoutes = (await RouteDapperRepository.GetAllAsync()).Where(entity =>
                        (entity.ModuleRelationshipId.HasValue && moduleRelationshipIds.Contains(entity.ModuleRelationshipId.Value)) ||
                        (entity.ModuleComponentId.HasValue && moduleComponentIds.Contains(entity.ModuleComponentId.Value)) ||
                        entity.ModuleId == module.Id).ToArray();
            CheckModuleRoutes(moduleRoutes);
            var moduleRouteIds = moduleRoutes.Select(entity => entity.Id);
            var routeRelaionships = (await RouteRelationshipDapperRepository.GetAllAsync()).Where(entity => moduleRouteIds.Contains(entity.ParentId));
            var rootRoutes = moduleRoutes.Where(entity => routeRelaionships.All(entity2 => entity2.ChildId != entity.Id));
            var roleRoutes = (await RoleRouteDapperRepository.GetAllAsync()).Where(entity => moduleRouteIds.Contains(entity.RouteId));
            var userId = AbpSession.UserId ?? 0;
            var userRoleIds = (await RoleUserDapperRepository.GetAllAsync(entity => entity.UserId == userId)).ToArray().Select(entity => entity.RoleId);
            var userRoutes = (await UserRouteDapperRepository.GetAllAsync(entity => entity.UserId == userId)).Where(entity => moduleRouteIds.Contains(entity.RouteId));

            var routes = new List<Entity.View.Route.Route>();
            var parentRoutes = new List<Entity.POCO.Route.Route>();
            var routeDictionary = new Dictionary<long, Entity.View.Route.Route>();
            Entity.View.Route.Route dtoRoute = null;
            foreach (var route in rootRoutes)
            {
                if (route.ModuleRelationshipId.HasValue)
                {
                    dtoRoute = new ModuleRoute
                    {
                        Path = route.Path,
                        LoadChildren = route.Config
                    };
                }
                else if (route.ModuleComponentId.HasValue)
                {
                    var moduleComponent = moduleComponents.FirstOrDefault(entity => entity.Id == route.ModuleComponentId);
                    var component = components.FirstOrDefault(entity => entity.Id == moduleComponent.ComponentId);
                    dtoRoute = new ComponentRoute
                    {
                        Path = route.Path,
                        Component = component.Name,
                        Data = string.IsNullOrEmpty(route.Config) ? null : JObject.Parse(route.Config),
                        Children = new List<Entity.View.Route.Route>()
                    };
                }
                else if (route.ModuleId.HasValue)
                {
                    var config = JObject.Parse(route.Config);
                    dtoRoute = new RedirectRoute()
                    {
                        Path = route.Path,
                        RedirectTo = config.Value<string>("redirectTo"),
                        PathMatch = config.Value<string>("patchMath")
                    };
                }
                var routeRoles = roleRoutes.Where(entity => entity.RouteId == route.Id);
                var userRoute = userRoutes.FirstOrDefault(entity => entity.RouteId == route.Id);
                if (
                    (userRoute != null && userRoute.HasPermission) ||
                    (routeRoles.Count() == 0) ||
                    (routeRoles.Count() > 0 && routeRoles.Any(entity => userRoleIds.Contains(entity.RoleId)))
                )
                {
                    routes.Add(dtoRoute);
                    routeDictionary.Add(route.Id, dtoRoute);
                    parentRoutes.Add(route);
                }
            }
            var parentRouteIds = parentRoutes.Select(entity => entity.Id).ToList();
            while (routeRelaionships.Any(entity => parentRouteIds.Contains(entity.ParentId)))
            {
                var routeRelationships2 = routeRelaionships.Where(entity => parentRouteIds.Contains(entity.ParentId));
                parentRoutes.Clear();
                foreach (var routeRelationship in routeRelationships2)
                {
                    var route = moduleRoutes.First(entity => entity.Id == routeRelationship.ChildId);
                    if (route.ModuleRelationshipId.HasValue)
                    {
                        dtoRoute = new ModuleRoute
                        {
                            Path = route.Path,
                            LoadChildren = route.Config
                        };
                    }
                    else if (route.ModuleComponentId.HasValue)
                    {
                        var moduleComponent =
                            moduleComponents.FirstOrDefault(entity => entity.Id == route.ModuleComponentId);
                        var component = components.FirstOrDefault(entity => entity.Id == moduleComponent.ComponentId);
                        dtoRoute = new ComponentRoute
                        {
                            Path = route.Path,
                            Component = component.Name,
                            Data = string.IsNullOrEmpty(route.Config) ? null : JObject.Parse(route.Config),
                            Children = new List<Entity.View.Route.Route>()
                        };
                    }
                    else if (route.ModuleId.HasValue)
                    {
                        var config = JObject.Parse(route.Config);
                        dtoRoute = new RedirectRoute()
                        {
                            Path = route.Path,
                            RedirectTo = config.Value<string>("redirectTo"),
                            PathMatch = config.Value<string>("patchMath")
                        };
                    }
                    var routeRoles = roleRoutes.Where(entity => entity.RouteId == route.Id);
                    var userRoute = userRoutes.FirstOrDefault(entity => entity.RouteId == route.Id);
                    if (
                        (userRoute != null && userRoute.HasPermission) ||
                        (routeRoles.Count() == 0) ||
                        (routeRoles.Count() > 0 && routeRoles.Any(entity => userRoleIds.Contains(entity.RoleId)))
                    )
                    {
                        if (routeDictionary[routeRelationship.ParentId] is ComponentRoute parentRoute)
                        {
                            parentRoute.Children.Add(dtoRoute);
                            routeDictionary.Add(route.Id, dtoRoute);
                            parentRoutes.Add(route);
                        }
                    }
                }
                parentRouteIds = parentRoutes.Select(entity => entity.Id).ToList();
            }
            return routes;
        }

        private static void CheckModuleRoutes(Entity.POCO.Route.Route[] moduleRoutes)
        {
            if (!moduleRoutes.Any())
            {
                throw new DemoApiException(2);
            }
        }

        private void CheckModule(Module module)
        {
            if (module == null)
            {
                throw new DemoApiException(1);
            }
            if (module.RequiredLogin && !AbpSession.UserId.HasValue)
            {
                throw new DemoApiException(3);
            }
        }
    }
}