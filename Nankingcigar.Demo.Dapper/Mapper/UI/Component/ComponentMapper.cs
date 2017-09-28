
using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.UI.Component
{
    public sealed class ComponentMapper : ClassMapper<Core.Entity.UI.Component.Component>
    {
        public ComponentMapper()
        {
            Table("Component");

            Map(entity => entity.ComponentModules).Ignore();

            AutoMap();
        }
    }
}
