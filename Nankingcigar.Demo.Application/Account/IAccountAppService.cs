using Abp.Application.Services;
using Nankingcigar.Demo.Application.Account.DTO;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Application.Account
{
    public interface IAccountAppService : IApplicationService
    {
        Task Register(RegisterInput input);
    }
}