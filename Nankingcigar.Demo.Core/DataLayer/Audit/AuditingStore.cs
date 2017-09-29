using Abp.Auditing;
using Abp.Dependency;
using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.Core.Extension.Repository;
using System.Threading.Tasks;
using Nankingcigar.Demo.Core.Extension.Repository.Dapper;

namespace Nankingcigar.Demo.Core.DataLayer.Audit
{
    public class AuditingStore : IAuditingStore, ITransientDependency
    {
        private readonly IDapperRepositoryExtension<AuditLog, long> _auditLogDapperRepository;

        public AuditingStore(IDapperRepositoryExtension<AuditLog, long> auditLogDapperRepository)
        {
            _auditLogDapperRepository = auditLogDapperRepository;
        }

        public virtual async Task SaveAsync(AuditInfo auditInfo)
        {
            await _auditLogDapperRepository.InsertAsync(AuditLog.CreateFromAuditInfo(auditInfo));
        }
    }
}