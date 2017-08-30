using Abp.Application.Services;
using Nankingcigar.Demo.Account.DTO;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Account
{
    public interface IAccountAppService : IApplicationService
    {
        Task Register(RegisterInput input);
    }
}