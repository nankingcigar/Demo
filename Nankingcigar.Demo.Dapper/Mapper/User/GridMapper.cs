using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.User;

namespace Nankingcigar.Demo.Dapper.Mapper.User
{
    public sealed class GridMapper : ClassMapper<Grid>
    {
        public GridMapper()
        {
            Table("vUserGrid");
            AutoMap();
        }
    }
}