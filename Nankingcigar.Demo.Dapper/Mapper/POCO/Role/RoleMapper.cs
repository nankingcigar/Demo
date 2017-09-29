using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.Role
{
    public sealed class RoleMapper : ClassMapper<Core.Entity.POCO.Role.Role>
    {
        public RoleMapper()
        {
            Table("Role");
            Map(entity => entity.RoleUsers).Ignore();
            Map(entity => entity.RoleApis).Ignore();
            Map(entity => entity.RoleRoutes).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}