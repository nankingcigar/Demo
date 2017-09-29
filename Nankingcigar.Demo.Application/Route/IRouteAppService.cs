using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Application.Route
{
    public interface IRouteAppService : IApplicationService
    {
        Task<IEnumerable<Core.Entity.View.Route.Route>> GetRoutesByModuleAndUser(string moduleName);
    }
}