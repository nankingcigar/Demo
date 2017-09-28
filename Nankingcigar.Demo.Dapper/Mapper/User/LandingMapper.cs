using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.User;

namespace Nankingcigar.Demo.Dapper.Mapper.User
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