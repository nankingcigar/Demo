using Abp;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.Core.Extension.Repository;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Nankingcigar.Demo.Core.Entity.POCO.Api;
using Nankingcigar.Demo.Core.Entity.POCO.Role;
using Nankingcigar.Demo.Core.Entity.POCO.User;
using Nankingcigar.Demo.Core.Extension.Repository.Dapper;
using Dapper;

namespace Nankingcigar.Demo.Core.DomainService.Permission
{
    internal class DemoPermissionChecker : IDemoPermissionChecker, ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }
        public IDapperRepositoryExtension<Api, long> ApiDapperRepository { get; set; }
        public IDapperRepositoryExtension<RoleApi, long> RoleApiDapperRepository { get; set; }
        public IDapperRepositoryExtension<RoleUser, long> RoleUserDapperRepository { get; set; }
        public IDapperRepositoryExtension<UserApi, long> UserApiDapperRepository { get; set; }

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
            var api = await ApiDapperRepository.FirstOrDefaultAsync(entity =>
                entity.Namespace == type.Namespace &&
                entity.ClassName == type.Name &&
                entity.MethodName == methodInfo.Name);
            if (api == null)
            {
                return true;
            }
            api.ApiRoles = (await RoleApiDapperRepository.GetAllAsync(entity => entity.ApiId == api.Id)).ToList();
            var userApi = await UserApiDapperRepository.FirstOrDefaultAsync(entity =>
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
            var userRoleIds = (await RoleUserDapperRepository.GetAllAsync(entity =>
                 entity.UserId == AbpSession.UserId.Value)).Select(entity => entity.RoleId);
            if (apiRoleIds.Any(apiRoleId => userRoleIds.Contains(apiRoleId)))
            {
                return true;
            }
            throw new DemoApiException(401);
        }
    }
}