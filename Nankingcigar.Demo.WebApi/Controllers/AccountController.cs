using System;
using Abp.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Nankingcigar.Demo.Core.Authorization;
using Nankingcigar.Demo.WebApi.DTO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Abp.Web.Models;
using Nankingcigar.Demo.Core.Entity;

namespace Nankingcigar.Demo.WebApi.Controllers
{
    public class AccountController : DemoApiControllerBase
    {
        private IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;

        private readonly LogInManager _logInManager;

        public AccountController(LogInManager logInManager)
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
    }
}