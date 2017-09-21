using Abp.Dependency;
using Microsoft.AspNet.Identity;
using Nankingcigar.Demo.Core.Extension.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.DataLayer.User
{
    public class UserStore :
        IUserStore<Entity.User.User, long>,
        IUserPasswordStore<Entity.User.User, long>,
        IUserEmailStore<Entity.User.User, long>,
        IQueryableUserStore<Entity.User.User, long>,
        IDisposable, ITransientDependency
    {
        public virtual IRepositoryExtension<Entity.User.User, long> UserRepository { get; set; }

        #region IQueryableUserStore

        public virtual IQueryable<Entity.User.User> Users => UserRepository.GetAll();

        #endregion IQueryableUserStore

        #region IUserStore

        public virtual async Task CreateAsync(Entity.User.User user)
        {
            await UserRepository.InsertAsync(user);
        }

        public virtual async Task UpdateAsync(Entity.User.User user)
        {
            await UserRepository.UpdateAsync(user);
        }

        public virtual async Task DeleteAsync(Entity.User.User user)
        {
            await UserRepository.DeleteAsync(user.Id);
        }

        public virtual async Task<Entity.User.User> FindByIdAsync(long userId)
        {
            return await UserRepository.CloseLazyLoad().FirstOrDefaultAsync(userId);
        }

        public virtual async Task<Entity.User.User> FindByNameAsync(string userName)
        {
            return await UserRepository.CloseLazyLoad().FirstOrDefaultAsync(user => user.UserName == userName);
        }

        #endregion IUserStore

        #region IUserPasswordStore

        public virtual Task SetPasswordHashAsync(Entity.User.User user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public virtual Task<string> GetPasswordHashAsync(Entity.User.User user)
        {
            return Task.FromResult(user.Password);
        }

        public virtual Task<bool> HasPasswordAsync(Entity.User.User user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.Password));
        }

        #endregion IUserPasswordStore

        #region IUserEmailStore

        public virtual Task SetEmailAsync(Entity.User.User user, string email)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public virtual Task<string> GetEmailAsync(Entity.User.User user)
        {
            return Task.FromResult(user.Email);
        }

        public virtual Task<bool> GetEmailConfirmedAsync(Entity.User.User user)
        {
            return Task.FromResult(false);
        }

        public virtual Task SetEmailConfirmedAsync(Entity.User.User user, bool confirmed)
        {
            return Task.FromResult(0);
        }

        public virtual async Task<Entity.User.User> FindByEmailAsync(string email)
        {
            return await UserRepository.CloseLazyLoad().FirstOrDefaultAsync(
                user => user.Email == email
            );
        }

        #endregion IUserEmailStore

        #region IDisposable

        public virtual void Dispose()
        {
            // No need to dispose since using IOC.
        }

        #endregion IDisposable
    }
}