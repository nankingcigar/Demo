using Abp.Application.Services;
using Nankingcigar.Demo.User.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.User
{
    public interface IUserAppService : IApplicationService
    {
        Task<DTO.User> GetCurrentUser();
    }
}