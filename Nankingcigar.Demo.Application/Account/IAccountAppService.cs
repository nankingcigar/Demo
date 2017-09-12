using System.Threading.Tasks;
using Abp.Application.Services;
using Nankingcigar.Demo.Application.Account.DTO;

namespace Nankingcigar.Demo.Application.Account
{
    public interface IAccountAppService : IApplicationService
    {
        Task Register(RegisterInput input);
    }
}