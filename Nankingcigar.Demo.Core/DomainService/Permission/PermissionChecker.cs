using System.Threading.Tasks;
using Abp;
using Abp.Authorization;
using Abp.Dependency;

namespace Nankingcigar.Demo.Core.DomainService.Permission
{
    internal class PermissionChecker : IPermissionChecker, ITransientDependency
    {
        public virtual Task<bool> IsGrantedAsync(string permissionName)
        {
            return Task.FromResult(true);
        }

        public virtual Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName)
        {
            return Task.FromResult(true);
        }
    }
}