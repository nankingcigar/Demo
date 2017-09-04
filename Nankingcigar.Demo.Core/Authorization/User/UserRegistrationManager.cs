using Abp.Domain.Services;
using Microsoft.AspNet.Identity;
using Nankingcigar.Demo.Core.Entity;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.Authorization.User
{
    public class UserRegistrationManager : DomainService
    {
        public UserManager UserManager { get; set; }
        private static PasswordHasher PasswordHasher => new PasswordHasher();

        public async Task RegisterAsync(string userName, string password, string email)
        {
            var user = await UserManager.FindByNameAsync(userName);
            if (user != null) throw new DemoApiException(1);
            user = new Entity.User
            {
                UserName = userName,
                Password = PasswordHasher.HashPassword(password),
                Email = email,
                IsActive = true
            };
            await UserManager.CreateAsync(user);
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}