using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.User
{
    public sealed class UserMapper : ClassMapper<Core.Entity.POCO.User.User>
    {
        public UserMapper()
        {
            Table("User");
            Map(entity => entity.UserName).Column("Name");
            Map(entity => entity.UserAuditLogs).Ignore();
            Map(entity => entity.ImpersonatorAuditLogs).Ignore();
            Map(entity => entity.UserRoles).Ignore();
            Map(entity => entity.UserApis).Ignore();
            Map(entity => entity.UserRoutes).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();


            Map(entity => entity.CreatedUsers).Ignore();
            Map(entity => entity.LastModifiedUsers).Ignore();
            Map(entity => entity.DeletedUsers).Ignore();


            Map(entity => entity.CreatedRoles).Ignore();
            Map(entity => entity.LastModifiedRoles).Ignore();
            Map(entity => entity.DeletedRoles).Ignore();


            Map(entity => entity.CreatedApis).Ignore();
            Map(entity => entity.LastModifiedApis).Ignore();
            Map(entity => entity.DeletedApis).Ignore();


            Map(entity => entity.CreatedRoleApis).Ignore();
            Map(entity => entity.LastModifiedRoleApis).Ignore();
            Map(entity => entity.DeletedRoleApis).Ignore();


            Map(entity => entity.CreatedRoleUsers).Ignore();
            Map(entity => entity.LastModifiedRoleUsers).Ignore();
            Map(entity => entity.DeletedRoleUsers).Ignore();


            Map(entity => entity.CreatedUserApis).Ignore();
            Map(entity => entity.LastModifiedUserApis).Ignore();
            Map(entity => entity.DeletedUserApis).Ignore();


            Map(entity => entity.CreatedModules).Ignore();
            Map(entity => entity.LastModifiedModules).Ignore();
            Map(entity => entity.DeletedModules).Ignore();


            Map(entity => entity.CreatedModuleRelationships).Ignore();
            Map(entity => entity.LastModifiedModuleRelationships).Ignore();
            Map(entity => entity.DeletedModuleRelationships).Ignore();


            Map(entity => entity.CreatedModuleComponents).Ignore();
            Map(entity => entity.LastModifiedModuleComponents).Ignore();
            Map(entity => entity.DeletedModuleComponents).Ignore();


            Map(entity => entity.CreatedComponents).Ignore();
            Map(entity => entity.LastModifiedComponents).Ignore();
            Map(entity => entity.DeletedComponents).Ignore();


            Map(entity => entity.CreatedRoutes).Ignore();
            Map(entity => entity.LastModifiedRoutes).Ignore();
            Map(entity => entity.DeletedRoutes).Ignore();


            Map(entity => entity.CreatedRouteRelationships).Ignore();
            Map(entity => entity.LastModifiedRouteRelationships).Ignore();
            Map(entity => entity.DeletedRouteRelationships).Ignore();


            Map(entity => entity.CreatedRoleRoutes).Ignore();
            Map(entity => entity.LastModifiedRoleRoutes).Ignore();
            Map(entity => entity.DeletedRoleRoutes).Ignore();


            Map(entity => entity.CreatedUserRoutes).Ignore();
            Map(entity => entity.LastModifiedUserRoutes).Ignore();
            Map(entity => entity.DeletedUserRoutes).Ignore();

            AutoMap();
        }
    }
}