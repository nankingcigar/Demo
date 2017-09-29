using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.UI.Module
{
    public sealed class ModuleComponentMapper : ClassMapper<Core.Entity.UI.Module.ModuleComponent>
    {
        public ModuleComponentMapper()
        {
            Table("ModuleComponent");

            Map(entity => entity.Routes).Ignore();
            Map(entity => entity.Module).Ignore();
            Map(entity => entity.Component).Ignore();

            AutoMap();
        }
    }
}