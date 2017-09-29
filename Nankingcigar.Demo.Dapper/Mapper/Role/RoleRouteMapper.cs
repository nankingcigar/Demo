using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.Role
{
    public sealed class RoleRouteMapper : ClassMapper<Core.Entity.Role.RoleRoute>
    {
        public RoleRouteMapper()
        {
            Table("RoleRoute");

            Map(entity => entity.Role).Ignore();
            Map(entity => entity.Route).Ignore();

            AutoMap();
        }
    }
}