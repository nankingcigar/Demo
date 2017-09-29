using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.POCO.User;

namespace Nankingcigar.Demo.Dapper.Mapper.POCO.User
{
    public sealed class UserRouteMapper : ClassMapper<UserRoute>
    {
        public UserRouteMapper()
        {
            Table("UserRoute");

            Map(entity => entity.User).Ignore();
            Map(entity => entity.Route).Ignore();


            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeleterUser).Ignore();

            AutoMap();
        }
    }
}