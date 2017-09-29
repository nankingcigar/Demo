using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.View.User;

namespace Nankingcigar.Demo.Dapper.Mapper.View.User
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