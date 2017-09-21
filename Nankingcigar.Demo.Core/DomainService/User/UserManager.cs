using Abp.Domain.Services;
using Microsoft.AspNet.Identity;
using Nankingcigar.Demo.Core.DataLayer.User;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.DomainService.User
{
    internal class UserManager : UserManager<Entity.User.User, long>, IDomainService
    {
        public UserManager(UserStore store) : base(store)
        {
        }

        public override async Task<ClaimsIdentity> CreateIdentityAsync(Entity.User.User user, string authenticationType)
        {
            var identity = await base.CreateIdentityAsync(user, authenticationType);
            return identity;
        }
    }
}