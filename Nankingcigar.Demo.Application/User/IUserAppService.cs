using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nankingcigar.Demo.Core.Entity.User;

namespace Nankingcigar.Demo.Application.User
{
    public interface IUserAppService : IApplicationService
    {
        Task<Landing> Get(long? userId);
        Task<IEnumerable<Grid>> GetAll();
    }
}