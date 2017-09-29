using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.Route
{
    public sealed class RouteMapper : ClassMapper<Core.Entity.POCO.Route.Route>
    {
        public RouteMapper()
        {
            Table("Route");

            Map(entity => entity.ModuleRelationship).Ignore();
            Map(entity => entity.ModuleComponent).Ignore();
            Map(entity => entity.Parents).Ignore();
            Map(entity => entity.Children).Ignore();
            Map(entity => entity.Module).Ignore();
            Map(entity => entity.RouteRoles).Ignore();
            Map(entity => entity.RouteUsers).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}