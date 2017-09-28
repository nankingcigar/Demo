using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.Role
{
    public sealed class RoleApiMapper : ClassMapper<Core.Entity.Role.RoleApi>
    {
        public RoleApiMapper()
        {
            Table("RoleApi");

            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            Map(entity => entity.Role).Ignore();
            Map(entity => entity.Api).Ignore();

            AutoMap();
        }
    }
}