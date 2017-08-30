using Abp.Authorization;
using Nankingcigar.Demo.Account.DTO;
using Nankingcigar.Demo.Core.Authorization.User;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Account
{
    internal class AccountAppService : DemoAppServiceBase, IAccountAppService
    {
        private readonly UserRegistrationManager _userRegistrationManager;

        public AccountAppService(UserRegistrationManager userRegistrationManager)
        {
            _userRegistrationManager = userRegistrationManager;
        }

        [AbpAllowAnonymous]
        public virtual async Task Register(RegisterInput input)
        {
            await _userRegistrationManager.RegisterAsync(
                input.UserName,
                input.Password,
                input.DisplayName
            );
        }
    }
}