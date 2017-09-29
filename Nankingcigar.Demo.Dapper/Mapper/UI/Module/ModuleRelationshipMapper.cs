using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.UI.Module
{
    public sealed class ModuleRelationshipMapper : ClassMapper<Core.Entity.UI.Module.ModuleRelationship>
    {
        public ModuleRelationshipMapper()
        {
            Table("ModuleRelationship");

            Map(entity => entity.Routes).Ignore();
            Map(entity => entity.Parent).Ignore();
            Map(entity => entity.Child).Ignore();

            AutoMap();
        }
    }
}