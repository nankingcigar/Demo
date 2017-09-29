using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.UI.Route
{
    public sealed class RouteRelationshipMapper : ClassMapper<Core.Entity.UI.Route.RouteRelationship>
    {
        public RouteRelationshipMapper()
        {
            Table("RouteRelationship");

            Map(entity => entity.Parent).Ignore();
            Map(entity => entity.Child).Ignore();

            AutoMap();
        }
    }
}