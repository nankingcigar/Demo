
using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.UI.Route
{
    public sealed class RouteMapper : ClassMapper<Core.Entity.UI.Route.Route>
    {
        public RouteMapper()
        {
            Table("Route");

            Map(entity => entity.ModuleRelationship).Ignore();
            Map(entity => entity.ModuleComponent).Ignore();
            Map(entity => entity.Parents).Ignore();
            Map(entity => entity.Children).Ignore();
            Map(entity => entity.Module).Ignore();

            AutoMap();
        }
    }
}
