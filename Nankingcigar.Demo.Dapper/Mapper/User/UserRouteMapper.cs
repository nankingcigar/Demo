using DapperExtensions.Mapper;

namespace Nankingcigar.Demo.Dapper.Mapper.User
{
    public sealed class UserRouteMapper : ClassMapper<Core.Entity.User.UserRoute>
    {
        public UserRouteMapper()
        {
            Table("UserRoute");

            Map(entity => entity.User).Ignore();
            Map(entity => entity.Route).Ignore();

            AutoMap();
        }
    }
}