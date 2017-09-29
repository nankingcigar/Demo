using Abp;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.Core.Entity.Api;
using Nankingcigar.Demo.Core.Entity.Role;
using Nankingcigar.Demo.Core.Entity.User;
using Nankingcigar.Demo.Core.Extension.Repository;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.DomainService.Permission
{
    internal class DemoPermissionChecker : IDemoPermissionChecker, ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }
        public IRepositoryExtension<Api, long> ApiRepository { get; set; }
        public IRepositoryExtension<RoleApi, long> RoleApiRepositoryExtension { get; set; }
        public IRepositoryExtension<RoleUser, long> RoleUserRepositoryExtension { get; set; }
        public IRepositoryExtension<UserApi, long> UserApiRepositoryExtension { get; set; }

        public Task<bool> IsGrantedAsync(string permissionName)
        {
            return Task.FromResult(true);
        }

        public Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName)
        {
            return Task.FromResult(true);
        }

        [UnitOfWork]
        public async Task<bool> IsGrantedAsync(MethodInfo methodInfo, Type type)
        {
            var api = ApiRepository.CloseLazyLoad()
                .GetAllIncluding(entity => entity.ApiRoles)
                .FirstOrDefault(entity =>
                    entity.Namespace == type.Namespace &&
                    entity.ClassName == type.Name &&
                    entity.MethodName == methodInfo.Name);
            if (api == null)
            {
                return true;
            }
            var userApi = await UserApiRepositoryExtension.FirstOrDefaultAsync(entity =>
                entity.UserId == AbpSession.UserId &&
                entity.ApiId == api.Id
            );
            if (userApi != null)
            {
                if (userApi.HasPermission)
                {
                    return true;
                }
                throw new DemoApiException(401);
            }
            if (!api.ApiRoles.Any())
            {
                return true;
            }
            var apiRoleIds = api.ApiRoles.Select(p => p.RoleId);
            var userRoleIds = (await RoleUserRepositoryExtension.GetAllListAsync(entity =>
                 entity.UserId == AbpSession.UserId.Value)).Select(entity => entity.RoleId);
            if (apiRoleIds.Any(apiRoleId => userRoleIds.Contains(apiRoleId)))
            {
                return true;
            }
            throw new DemoApiException(401);
        }
    }
}