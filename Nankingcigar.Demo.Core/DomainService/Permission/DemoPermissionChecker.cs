using Abp;
using Abp.Authorization;
using Abp.Dependency;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Reflection;
using Abp.Runtime.Session;
using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.Core.Extension.Repository;

namespace Nankingcigar.Demo.Core.DomainService.Permission
{
    internal class DemoPermissionChecker : IDemoPermissionChecker, ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }
        public virtual IRepositoryExtension<Entity.Api.Api, long> ApiRepository { get; set; }
        public virtual IRepositoryExtension<Entity.User.UserPermission, long> UserPermissionRepository { get; set; }

        public virtual Task<bool> IsGrantedAsync(string permissionName)
        {
            return Task.FromResult(true);
        }

        public virtual Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName)
        {
            return Task.FromResult(true);
        }

        public virtual async Task<bool> IsGrantedAsync(MethodInfo methodInfo, Type type)
        {
            var api = ApiRepository
                .GetAllIncluding(entity => entity.ApiPermissions)
                .FirstOrDefault(entity =>
                    entity.Namespace == type.Namespace &&
                    entity.ClassName == type.Name &&
                    entity.MethodName == methodInfo.Name
                );
            if (api == null || !api.ApiPermissions.Any())
            {
                return true;
            }
            var apiPermissions = api.ApiPermissions.Select(entity => entity.PermissionId);
            var userPermissions = (await UserPermissionRepository
                .GetAllListAsync(entity => entity.UserId == AbpSession.UserId.Value))
                .Select(entity => entity.PermissionId).ToList();
            if (!apiPermissions.All(apiPermission => userPermissions.Contains(apiPermission)))
            {
                throw new DemoApiException(401);
            }
            return true;
        }
    }
}