using Abp.Authorization;
using Nankingcigar.Demo.Application.Route.DTO;
using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.Dapper.Extend;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nankingcigar.Demo.Core.Entity.POCO.Component;
using Nankingcigar.Demo.Core.Entity.POCO.Module;
using Nankingcigar.Demo.Core.Entity.POCO.Role;
using Nankingcigar.Demo.Core.Entity.POCO.Route;
using Nankingcigar.Demo.Core.Entity.POCO.User;

namespace Nankingcigar.Demo.Application.Route
{
    internal class RouteAppService : DemoAppServiceBase, IRouteAppService
    {
        private readonly IDapperRepositoryExtension<Module, long> _moduleDapperRepository;
        private readonly IDapperRepositoryExtension<ModuleRelationship, long> _moduleRelationshipDapperRepository;
        private readonly IDapperRepositoryExtension<Component, long> _componentDapperRepository;
        private readonly IDapperRepositoryExtension<ModuleComponent, long> _moduleComponentDapperRepository;
        private readonly IDapperRepositoryExtension<Core.Entity.POCO.Route.Route, long> _routeDapperRepository;
        private readonly IDapperRepositoryExtension<RouteRelationship, long> _routeRelationshipDapperRepository;
        private readonly IDapperRepositoryExtension<RoleRoute, long> _roleRouteDapperRepository;
        private readonly IDapperRepositoryExtension<RoleUser, long> _roleUserDapperRepository;
        private readonly IDapperRepositoryExtension<UserRoute, long> _userRouteDapperRepository;

        public RouteAppService(
            IDapperRepositoryExtension<Module, long> moduleDapperRepository,
            IDapperRepositoryExtension<ModuleRelationship, long> moduleRelationshipDapperRepository,
            IDapperRepositoryExtension<Component, long> componentDapperRepository,
            IDapperRepositoryExtension<ModuleComponent, long> moduleComponentDapperRepository,
            IDapperRepositoryExtension<Core.Entity.POCO.Route.Route, long> routeDapperRepository,
            IDapperRepositoryExtension<RouteRelationship, long> routeRelationshipDapperRepository,
            IDapperRepositoryExtension<RoleRoute, long> roleRouteDapperRepository,
            IDapperRepositoryExtension<RoleUser, long> roleUserDapperRepository,
            IDapperRepositoryExtension<UserRoute, long> userRouteDapperRepository
        )
        {
            _moduleDapperRepository = moduleDapperRepository;
            _moduleRelationshipDapperRepository = moduleRelationshipDapperRepository;
            _componentDapperRepository = componentDapperRepository;
            _moduleComponentDapperRepository = moduleComponentDapperRepository;
            _routeDapperRepository = routeDapperRepository;
            _routeRelationshipDapperRepository = routeRelationshipDapperRepository;
            _roleRouteDapperRepository = roleRouteDapperRepository;
            _userRouteDapperRepository = userRouteDapperRepository;
            _roleUserDapperRepository = roleUserDapperRepository;
        }

        [AbpAllowAnonymous]
        public async Task<IEnumerable<DTO.Route>> GetRoutes(string moduleName)
        {
            var module = await _moduleDapperRepository.FirstOrDefaultAsync(entity => entity.Name == moduleName);
            if (module == null)
            {
                throw new DemoApiException(1);
            }
            if (module.RequiredLogin && !AbpSession.UserId.HasValue)
            {
                throw new DemoApiException(3);
            }
            var moduleRelationships =
                (await _moduleRelationshipDapperRepository.GetAllAsync(entity => entity.ParentId == module.Id)).ToArray();
            var moduleComponents = (await _moduleComponentDapperRepository.GetAllAsync(entity => entity.ModuleId == module.Id)).ToArray();
            IEnumerable<Component> components = new List<Component>();
            var componentIds = moduleComponents.Select(entity => entity.ComponentId);
            if (moduleComponents.Any())
            {
                components = (await _componentDapperRepository.GetAllAsync()).Where(entity => componentIds.Contains(entity.Id));
            }
            var moduleRelationshipIds = moduleRelationships.Select(entity => entity.Id);
            var moduleComponentIds = moduleComponents.Select(entity => entity.Id);
            var moduleRoutes = (await _routeDapperRepository.GetAllAsync()).Where(
                entity => (entity.ModuleRelationshipId.HasValue && moduleRelationshipIds.Contains(entity.ModuleRelationshipId.Value)) ||
                          (entity.ModuleComponentId.HasValue && moduleComponentIds.Contains(entity.ModuleComponentId.Value)) ||
                          entity.ModuleId == module.Id).ToArray();
            if (!moduleRoutes.Any())
            {
                throw new DemoApiException(2);
            }
            var moduleRouteIds = moduleRoutes.Select(entity => entity.Id);
            var routeRelaionships =
                (await _routeRelationshipDapperRepository.GetAllAsync()).Where(entity =>
                    moduleRouteIds.Contains(entity.ParentId));
            var rootRoutes =
                moduleRoutes.Where(entity => routeRelaionships.All(entity2 => entity2.ChildId != entity.Id));
            var roleRoutes = (await _roleRouteDapperRepository.GetAllAsync()).Where(entity => moduleRouteIds.Contains(entity.RouteId));
            var userId = AbpSession.UserId ?? 0;
            var userRoleIds = (await _roleUserDapperRepository.GetAllAsync(entity => entity.UserId == userId)).ToArray().Select(entity => entity.RoleId);
            var userRoutes = (await _userRouteDapperRepository.GetAllAsync(entity => entity.UserId == userId))
                .Where(entity => moduleRouteIds.Contains(entity.RouteId));
            var routes = new List<DTO.Route>();
            var parentRoutes = new List<Core.Entity.POCO.Route.Route>();
            var routeDictionary = new Dictionary<long, DTO.Route>();
            DTO.Route dtoRoute = null;
            foreach (var route in rootRoutes)
            {
                if (route.ModuleRelationshipId.HasValue)
                {
                    dtoRoute = new DTO.ModuleRoute
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
                    dtoRoute = new DTO.ComponentRoute
                    {
                        Path = route.Path,
                        Component = component.Name,
                        Data = string.IsNullOrEmpty(route.Config) ? null : JObject.Parse(route.Config),
                        Children = new List<DTO.Route>()
                    };
                }
                else if (route.ModuleId.HasValue)
                {
                    var config = JObject.Parse(route.Config);
                    dtoRoute = new DTO.RedirectRoute()
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
                        dtoRoute = new DTO.ModuleRoute
                        {
                            Path = route.Path,
                            LoadChildren = route.Config
                        };
                    }
                    else if (route.ModuleComponentId.HasValue)
                    {
                        var moduleComponent = moduleComponents.FirstOrDefault(entity => entity.Id == route.ModuleComponentId);
                        var component = components.FirstOrDefault(entity => entity.Id == moduleComponent.ComponentId);
                        dtoRoute = new DTO.ComponentRoute
                        {
                            Path = route.Path,
                            Component = component.Name,
                            Data = string.IsNullOrEmpty(route.Config) ? null : JObject.Parse(route.Config),
                            Children = new List<DTO.Route>()
                        };
                    }
                    else if (route.ModuleId.HasValue)
                    {
                        var config = JObject.Parse(route.Config);
                        dtoRoute = new DTO.RedirectRoute()
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
    }
}