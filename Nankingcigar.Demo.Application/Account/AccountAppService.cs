using Abp.Authorization;
using Nankingcigar.Demo.Application.Account.DTO;
using System.Threading.Tasks;
using Nankingcigar.Demo.Core.DomainService.Registration;

namespace Nankingcigar.Demo.Application.Account
{
    internal class AccountAppService : DemoAppServiceBase, IAccountAppService
    {
        private readonly IUserRegistrationManager _userRegistrationManager;

        public AccountAppService(IUserRegistrationManager userRegistrationManager)
        {
            _userRegistrationManager = userRegistrationManager;
        }

        [AbpAllowAnonymous]
        public virtual async Task Register(RegisterInput input)
        {
            await _userRegistrationManager.RegisterAsync(
                input.UserName,
                input.Password,
                input.Email
            );
        }
    }
}