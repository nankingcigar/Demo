using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.POCO.Role;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.Role
{
    public sealed class RoleApiMapper : ClassMapper<RoleApi>
    {
        public RoleApiMapper()
        {
            Table("RoleApi");

            Map(entity => entity.Role).Ignore();
            Map(entity => entity.Api).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}