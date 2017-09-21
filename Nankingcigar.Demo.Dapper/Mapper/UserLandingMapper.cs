using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.User;

namespace Nankingcigar.Demo.Dapper.Mapper
{
    public sealed class UserLandingMapper : ClassMapper<Landing>
    {
        public UserLandingMapper()
        {
            Table("UserLanding");
            AutoMap();
        }
    }
}