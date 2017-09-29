using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.Api
{
    public sealed class ApiMapper : ClassMapper<Core.Entity.POCO.Api.Api>
    {
        public ApiMapper()
        {
            Table("Api");

            Map(entity => entity.ApiRoles).Ignore();
            Map(entity => entity.ApiUsers).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}