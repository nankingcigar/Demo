using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.POCO.Role;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.Role
{
    public sealed class RoleRouteMapper : ClassMapper<RoleRoute>
    {
        public RoleRouteMapper()
        {
            Table("RoleRoute");

            Map(entity => entity.Role).Ignore();
            Map(entity => entity.Route).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}