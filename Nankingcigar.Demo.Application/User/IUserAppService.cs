using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Application.User
{
    public interface IUserAppService : IApplicationService
    {
        Task<DTO.User> Get(long? userId);
        Task<IEnumerable<DTO.User2>> GetAll();
    }
}