using Abp.Domain.Services;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.Authorization.User
{
    public class UserManager : UserManager<Entity.User, long>, IDomainService
    {
        public UserManager(UserStore store) : base(store)
        {
        }

        public override async Task<ClaimsIdentity> CreateIdentityAsync(Entity.User user, string authenticationType)
        {
            var identity = await base.CreateIdentityAsync(user, authenticationType);
            return identity;
        }
    }
}