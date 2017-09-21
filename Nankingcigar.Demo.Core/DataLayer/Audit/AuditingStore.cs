using Abp.Auditing;
using Abp.Dependency;
using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.Core.Extension.Repository;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.DataLayer.Audit
{
    public class AuditingStore : IAuditingStore, ITransientDependency
    {
        private readonly IRepositoryExtension<AuditLog, long> _auditLogRepository;

        public AuditingStore(IRepositoryExtension<AuditLog, long> auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public virtual async Task SaveAsync(AuditInfo auditInfo)
        {
            await _auditLogRepository.InsertAsync(AuditLog.CreateFromAuditInfo(auditInfo));
        }
    }
}