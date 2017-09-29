using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.POCO.Module;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.Module
{
    public sealed class ModuleRelationshipMapper : ClassMapper<ModuleRelationship>
    {
        public ModuleRelationshipMapper()
        {
            Table("ModuleRelationship");

            Map(entity => entity.Routes).Ignore();
            Map(entity => entity.Parent).Ignore();
            Map(entity => entity.Child).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}