using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.UI.Module
{
    public sealed class ModuleMapper : ClassMapper<Core.Entity.UI.Module.Module>
    {
        public ModuleMapper()
        {
            Table("Module");

            Map(entity => entity.Parents).Ignore();
            Map(entity => entity.Children).Ignore();
            Map(entity => entity.ModuleComponents).Ignore();
            Map(entity => entity.Routes).Ignore();

            AutoMap();
        }
    }
}