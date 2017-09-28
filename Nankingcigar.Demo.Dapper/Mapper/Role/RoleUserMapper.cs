using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.Role
{
    public sealed class RoleUserMapper : ClassMapper<Core.Entity.Role.RoleUser>
    {
        public RoleUserMapper()
        {
            Table("RoleUser");

            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            Map(entity => entity.Role).Ignore();
            Map(entity => entity.User).Ignore();

            AutoMap();
        }
    }
}