﻿using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.User;

namespace Nankingcigar.Demo.Dapper.Mapper
{
    public sealed class UserGridMapper : ClassMapper<Grid>
    {
        public UserGridMapper()
        {
            Table("vUserGrid");
            AutoMap();
        }
    }
}