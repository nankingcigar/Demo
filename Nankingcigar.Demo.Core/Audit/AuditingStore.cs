using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Dependency;
using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.Core.Extend;

namespace Nankingcigar.Demo.Core.Audit
{
    public class AuditingStore : IAuditingStore, ITransientDependency
    {
        private readonly IRepositoryExtend<AuditLog, long> _auditLogRepository;

        public AuditingStore(IRepositoryExtend<AuditLog, long> auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public virtual async Task SaveAsync(AuditInfo auditInfo)
        {
            await _auditLogRepository.InsertAsync(AuditLog.CreateFromAuditInfo(auditInfo));
        }
    }
}
