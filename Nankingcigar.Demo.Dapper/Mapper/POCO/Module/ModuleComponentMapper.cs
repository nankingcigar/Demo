using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.POCO.Module;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.Module
{
    public sealed class ModuleComponentMapper : ClassMapper<ModuleComponent>
    {
        public ModuleComponentMapper()
        {
            Table("ModuleComponent");

            Map(entity => entity.Routes).Ignore();
            Map(entity => entity.Module).Ignore();
            Map(entity => entity.Component).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}