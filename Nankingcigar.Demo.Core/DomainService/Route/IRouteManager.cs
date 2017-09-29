using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.DomainService.Route
{
    public interface IRouteManager : IDomainService
    {
        Task<IEnumerable<Entity.View.Route.Route>> GetRoutesByModuleAndUser(string moduleName);
    }
}