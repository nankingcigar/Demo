using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Nankingcigar.Demo.Application.Route.DTO;
using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.Core.Entity.UI.Component;
using Nankingcigar.Demo.Core.Entity.UI.Module;
using Nankingcigar.Demo.Core.Extension.Repository;
using Nankingcigar.Demo.Dapper.Extend;
using Newtonsoft.Json.Linq;

namespace Nankingcigar.Demo.Application.Route
{
    internal class RouteAppService : DemoAppServiceBase, IRouteAppService
    {
        private readonly IDapperRepositoryExtension<Module, long> _moduleDapperRepository;
        private readonly IDapperRepositoryExtension<ModuleRelationship, long> _moduleRelationshipDapperRepository;
        private readonly IDapperRepositoryExtension<Component, long> _componentDapperRepository;
        private readonly IDapperRepositoryExtension<ModuleComponent, long> _moduleComponentDapperRepository;
        private readonly IDapperRepositoryExtension<Core.Entity.UI.Route.Route, long> _routeDapperRepository;
        private readonly IDapperRepositoryExtension<Core.Entity.UI.Route.RouteRelationship, long> _routeRelationshipDapperRepository;

        public RouteAppService(
            IDapperRepositoryExtension<Module, long> moduleDapperRepository,
            IDapperRepositoryExtension<ModuleRelationship, long> moduleRelationshipDapperRepository,
            IDapperRepositoryExtension<Component, long> componentDapperRepository,
            IDapperRepositoryExtension<ModuleComponent, long> moduleComponentDapperRepository,
        IDapperRepositoryExtension<Core.Entity.UI.Route.Route, long> routeDapperRepository,
            IDapperRepositoryExtension<Core.Entity.UI.Route.RouteRelationship, long> routeRelationshipDapperRepository
        )
        {
            _moduleDapperRepository = moduleDapperRepository;
            _moduleRelationshipDapperRepository = moduleRelationshipDapperRepository;
            _componentDapperRepository = componentDapperRepository;
            _moduleComponentDapperRepository = moduleComponentDapperRepository;
            _routeDapperRepository = routeDapperRepository;
            _routeRelationshipDapperRepository = routeRelationshipDapperRepository;
        }

        [AbpAllowAnonymous]
        public async Task<IEnumerable<DTO.Route>> GetRoutes(string moduleName)
        {
            var module = await _moduleDapperRepository.FirstOrDefaultAsync(entity => entity.Name == moduleName);
            if (module == null)
            {
                throw new DemoApiException(1);
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
            var routes = new List<DTO.Route>();
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
                routes.Add(dtoRoute);
                routeDictionary.Add(route.Id, dtoRoute);
            }

            var parentRoutes = rootRoutes;
            var parentRouteIds = parentRoutes.Select(entity => entity.Id);
            while (routeRelaionships.Any(entity => parentRouteIds.Contains(entity.ParentId)))
            {
                var routeRelationships2 = routeRelaionships.Where(entity => parentRouteIds.Contains(entity.ParentId));
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
                    if (routeDictionary[routeRelationship.ParentId] is ComponentRoute parentRoute)
                    {
                        parentRoute.Children.Add(dtoRoute);
                    }
                    routeDictionary.Add(route.Id, dtoRoute);
                }
                var childIds = routeRelationships2.Select(entity => entity.ChildId).ToArray();
                parentRoutes = moduleRoutes.Where(entity => childIds.Contains(entity.Id));
                parentRouteIds = parentRoutes.Select(entity => entity.Id);
            }
            return routes;
        }
    }
}
