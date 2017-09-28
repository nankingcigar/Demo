using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.Api
{
    public sealed class ApiMapper : ClassMapper<Core.Entity.Api.Api>
    {
        public ApiMapper()
        {
            Table("Api");

            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            Map(entity => entity.ApiRoles).Ignore();
            Map(entity => entity.ApiUsers).Ignore();

            AutoMap();
        }
    }
}