using Abp.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Nankingcigar.Demo.Core.DomainService.LogIn;
using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.WebApi.DTO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Nankingcigar.Demo.WebApi.Controllers
{
    public class AccountController : DemoApiControllerBase
    {
        private IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;

        private readonly ILogInManager _logInManager;

        public AccountController(ILogInManager logInManager)
        {
            _logInManager = logInManager;
        }

        [AllowAnonymous]
        [AbpAllowAnonymous]
        [HttpPost]
        public virtual async Task Authenticate(LoginInput input)
        {
            var identity = await _logInManager.LoginAsync(input.UserName, input.Password);
            if (identity == null) throw new DemoApiException(1);
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(identity);
        }

        [HttpGet]
        public virtual void LogOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}