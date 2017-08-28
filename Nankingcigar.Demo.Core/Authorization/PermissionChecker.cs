using Abp;
using Abp.Authorization;
using Abp.Dependency;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.Authorization
{
    public class PermissionChecker : IPermissionChecker, ITransientDependency
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