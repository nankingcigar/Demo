using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.Module
{
    public sealed class ModuleMapper : ClassMapper<Core.Entity.POCO.Module.Module>
    {
        public ModuleMapper()
        {
            Table("Module");

            Map(entity => entity.Parents).Ignore();
            Map(entity => entity.Children).Ignore();
            Map(entity => entity.ModuleComponents).Ignore();
            Map(entity => entity.Routes).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}