using Abp.Domain.Uow;
using Abp.Timing;
using Microsoft.AspNet.Identity;
using Nankingcigar.Demo.Core.DomainService.User;
using Nankingcigar.Demo.Core.EventBus.User;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.DomainService.Login
{
    internal class LoginManager : DemoDomainServiceBase, ILoginManager
    {
        public virtual UserManager UserManager { get; set; }

        [UnitOfWork]
        public virtual async Task<ClaimsIdentity> LoginAsync(string userNameOrEmailAddress, string plainPassword)
        {
            var user = await UserManager.FindByNameAsync(userNameOrEmailAddress);
            if (user == null) return null;
            var verificationResult = UserManager.PasswordHasher.VerifyHashedPassword(user.Password, plainPassword);
            if (verificationResult == PasswordVerificationResult.Failed) return null;
            if (verificationResult == PasswordVerificationResult.SuccessRehashNeeded) return null;
            if (!user.IsActive) return null;
            user.LastLoginTime = Clock.Now;
            await UserManager.UpdateAsync(user);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            EventBus.Trigger(new LoginEventData() { Data = user });
            return await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}