using DapperExtensions.Mapper;
using Nankingcigar.Demo.Core.Entity;

namespace Nankingcigar.Demo.Dapper.Mapper
{
    public sealed class AuditLogMapper : ClassMapper<AuditLog>
    {
        public AuditLogMapper()
        {
            Table("AuditLog");
            Map(entity => entity.User).Ignore();
            Map(entity => entity.Impersonator).Ignore();
            AutoMap();
        }
    }
}