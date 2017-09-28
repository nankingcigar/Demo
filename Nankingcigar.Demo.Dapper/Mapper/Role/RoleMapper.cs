using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.Role
{
    public sealed class RoleMapper : ClassMapper<Core.Entity.Role.Role>
    {
        public RoleMapper()
        {
            Table("Role");

            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            Map(entity => entity.RoleUsers).Ignore();
            Map(entity => entity.RoleApis).Ignore();

            AutoMap();
        }
    }
}