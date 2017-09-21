using Abp.Authorization;
using Nankingcigar.Demo.Application.Account.DTO;
using Nankingcigar.Demo.Core.DomainService.Registration;
using System.Threading.Tasks;

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