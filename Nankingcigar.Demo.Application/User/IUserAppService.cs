using System.Threading.Tasks;
using Abp.Application.Services;

namespace Nankingcigar.Demo.Application.User
{
    public interface IUserAppService : IApplicationService
    {
        Task<DTO.User> GetCurrentUser();
    }
}