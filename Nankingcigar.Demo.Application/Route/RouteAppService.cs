using Abp.Authorization;
using Nankingcigar.Demo.Core.DomainService.Route;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Application.Route
{
    internal class RouteAppService : DemoAppServiceBase, IRouteAppService
    {
        private readonly IRouteManager _routeManager;

        public RouteAppService(
            IRouteManager routeManager
        )
        {
            _routeManager = routeManager;
        }

        [AbpAllowAnonymous]
        public async Task<IEnumerable<Core.Entity.View.Route.Route>> GetRoutesByModuleAndUser(string moduleName)
        {
            return await _routeManager.GetRoutesByModuleAndUser(moduleName);
        }
    }
}