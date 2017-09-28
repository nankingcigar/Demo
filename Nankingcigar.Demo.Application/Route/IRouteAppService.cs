using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace Nankingcigar.Demo.Application.Route
{
    public interface IRouteAppService : IApplicationService
    {
        Task<IEnumerable<DTO.Route>> GetRoutes(string moduleName);
    }
}
