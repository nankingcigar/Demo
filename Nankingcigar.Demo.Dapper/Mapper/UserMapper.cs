using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity.User;

namespace Nankingcigar.Demo.Dapper.Mapper
{
    public sealed class UserMapper : ClassMapper<User>
    {
        public UserMapper()
        {
            Table("User");
            Map(entity => entity.UserName).Column("Name");
            Map(entity => entity.CreatedUsers).Ignore();
            Map(entity => entity.CreatorUser).Ignore();
            Map(entity => entity.LastModifiedUsers).Ignore();
            Map(entity => entity.LastModifierUser).Ignore();
            Map(entity => entity.DeletedUsers).Ignore();
            Map(entity => entity.DeleterUser).Ignore();
            Map(entity => entity.UserAuditLogs).Ignore();
            Map(entity => entity.ImpersonatorAuditLogs).Ignore();
            AutoMap();
        }
    }
}