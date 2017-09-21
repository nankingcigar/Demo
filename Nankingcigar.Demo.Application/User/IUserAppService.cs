using Abp.Application.Services;
using Nankingcigar.Demo.Core.Entity.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Application.User
{
    public interface IUserAppService : IApplicationService
    {
        Task<Landing> Get(long? userId);

        Task<IEnumerable<Grid>> GetAll();
    }
}