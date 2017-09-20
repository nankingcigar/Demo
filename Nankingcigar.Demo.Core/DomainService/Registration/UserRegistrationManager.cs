using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Nankingcigar.Demo.Core.DomainService.User;
using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.Core.EventBus;
using Nankingcigar.Demo.Core.EventBus.User;

namespace Nankingcigar.Demo.Core.DomainService.Registration
{
    internal class UserRegistrationManager : DemoDomainServiceBase, IUserRegistrationManager
    {
        public UserManager UserManager { get; set; }
        private static PasswordHasher PasswordHasher => new PasswordHasher();

        public async Task RegisterAsync(string userName, string password, string email)
        {
            var user = await UserManager.FindByNameAsync(userName);
            if (user != null) throw new DemoApiException(1);
            user = new Entity.User.User
            {
                UserName = userName,
                Password = PasswordHasher.HashPassword(password),
                Email = email,
                IsActive = true
            };
            await UserManager.CreateAsync(user);
            await CurrentUnitOfWork.SaveChangesAsync();
            EventBus.Trigger(new RegistrationEventData() { Data = user });
        }
    }
}