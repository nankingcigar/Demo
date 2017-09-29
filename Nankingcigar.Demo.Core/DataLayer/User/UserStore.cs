using Abp.Dependency;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Nankingcigar.Demo.Core.Extension.Repository.Dapper;

namespace Nankingcigar.Demo.Core.DataLayer.User
{
    public class UserStore :
        IUserStore<Entity.POCO.User.User, long>,
        IUserPasswordStore<Entity.POCO.User.User, long>,
        IUserEmailStore<Entity.POCO.User.User, long>,
        IQueryableUserStore<Entity.POCO.User.User, long>,
        IDisposable, 
        ITransientDependency
    {
        public virtual IDapperRepositoryExtension<Entity.POCO.User.User, long> UserDapperRepository { get; set; }

        #region IQueryableUserStore

        public virtual IQueryable<Entity.POCO.User.User> Users => UserDapperRepository.GetAll().AsQueryable();

        #endregion IQueryableUserStore

        #region IUserStore

        public virtual async Task CreateAsync(Entity.POCO.User.User user)
        {
            await UserDapperRepository.InsertAsync(user);
        }

        public virtual async Task UpdateAsync(Entity.POCO.User.User user)
        {
            await UserDapperRepository.UpdateAsync(user);
        }

        public virtual async Task DeleteAsync(Entity.POCO.User.User user)
        {
            await UserDapperRepository.DeleteAsync(user);
        }

        public virtual async Task<Entity.POCO.User.User> FindByIdAsync(long userId)
        {
            return await UserDapperRepository.FirstOrDefaultAsync(userId);
        }

        public virtual async Task<Entity.POCO.User.User> FindByNameAsync(string userName)
        {
            return await UserDapperRepository.FirstOrDefaultAsync(user => user.UserName == userName);
        }

        #endregion IUserStore

        #region IUserPasswordStore

        public virtual Task SetPasswordHashAsync(Entity.POCO.User.User user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public virtual Task<string> GetPasswordHashAsync(Entity.POCO.User.User user)
        {
            return Task.FromResult(user.Password);
        }

        public virtual Task<bool> HasPasswordAsync(Entity.POCO.User.User user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.Password));
        }

        #endregion IUserPasswordStore

        #region IUserEmailStore

        public virtual Task SetEmailAsync(Entity.POCO.User.User user, string email)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public virtual Task<string> GetEmailAsync(Entity.POCO.User.User user)
        {
            return Task.FromResult(user.Email);
        }

        public virtual Task<bool> GetEmailConfirmedAsync(Entity.POCO.User.User user)
        {
            return Task.FromResult(false);
        }

        public virtual Task SetEmailConfirmedAsync(Entity.POCO.User.User user, bool confirmed)
        {
            return Task.FromResult(0);
        }

        public virtual async Task<Entity.POCO.User.User> FindByEmailAsync(string email)
        {
            return await UserDapperRepository.FirstOrDefaultAsync(
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