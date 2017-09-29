using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.Component
{
    public sealed class ComponentMapper : ClassMapper<Core.Entity.POCO.Component.Component>
    {
        public ComponentMapper()
        {
            Table("Component");

            Map(entity => entity.ComponentModules).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}