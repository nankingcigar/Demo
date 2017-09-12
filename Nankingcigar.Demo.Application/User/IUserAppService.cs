using Abp.Application.Services;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Application.User
{
    public interface IUserAppService : IApplicationService
    {
        Task<DTO.User> GetCurrentUser();
    }
}