using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.POCO.Role;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.Role
{
    public sealed class RoleUserMapper : ClassMapper<RoleUser>
    {
        public RoleUserMapper()
        {
            Table("RoleUser");

            Map(entity => entity.Role).Ignore();
            Map(entity => entity.User).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}