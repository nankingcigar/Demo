using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.View.User;

namespace Nankingcigar.Demo.Dapper.Mapper.View.User
{
    public sealed class LandingMapper : ClassMapper<Landing>
    {
        public LandingMapper()
        {
            Table("vUserLanding");
            AutoMap();
        }
    }
}