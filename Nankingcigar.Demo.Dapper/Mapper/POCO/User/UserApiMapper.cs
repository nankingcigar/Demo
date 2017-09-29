using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.POCO.User;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.User
{
    public sealed class UserApiMapper : ClassMapper<UserApi>
    {
        public UserApiMapper()
        {
            Table("UserApi");

            Map(entity => entity.User).Ignore();
            Map(entity => entity.Api).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}