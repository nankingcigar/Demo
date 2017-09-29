using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.POCO.Route;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.Route
{
    public sealed class RouteRelationshipMapper : ClassMapper<RouteRelationship>
    {
        public RouteRelationshipMapper()
        {
            Table("RouteRelationship");

            Map(entity => entity.Parent).Ignore();
            Map(entity => entity.Child).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}