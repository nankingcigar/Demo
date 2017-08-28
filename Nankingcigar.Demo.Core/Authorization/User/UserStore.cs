using Abp.Dependency;
using Microsoft.AspNet.Identity;
using Nankingcigar.Demo.Core.Extend;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.Authorization.User
{
    public class UserStore :
        IUserStore<Entity.User, long>,
        IUserPasswordStore<Entity.User, long>,
        IQueryableUserStore<Entity.User, long>,
        IDisposable, ITransientDependency
    {
        public virtual IRepositoryExtend<Entity.User, long> UserRepository { get; set; }

        #region IQueryableUserStore

        public virtual IQueryable<Entity.User> Users => UserRepository.GetAll();

        #endregion IQueryableUserStore

        #region IUserStore

        public virtual async Task CreateAsync(Entity.User user)
        {
            await UserRepository.InsertAsync(user);
        }

        public virtual async Task UpdateAsync(Entity.User user)
        {
            await UserRepository.UpdateAsync(user);
        }

        public virtual async Task DeleteAsync(Entity.User user)
        {
            await UserRepository.DeleteAsync(user.Id);
        }

        public virtual async Task<Entity.User> FindByIdAsync(long userId)
        {
            return await UserRepository.FirstOrDefaultAsync(userId);
        }

        public virtual async Task<Entity.User> FindByNameAsync(string userName)
        {
            return await UserRepository.FirstOrDefaultAsync(user => user.UserName == userName);
        }

        #endregion IUserStore

        #region IUserPasswordStore

        public virtual Task SetPasswordHashAsync(Entity.User user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public virtual Task<string> GetPasswordHashAsync(Entity.User user)
        {
            return Task.FromResult(user.Password);
        }

        public virtual Task<bool> HasPasswordAsync(Entity.User user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.Password));
        }

        #endregion IUserPasswordStore

        #region IDisposable

        public virtual void Dispose()
        {
            // No need to dispose since using IOC.
        }

        #endregion IDisposable
    }
}