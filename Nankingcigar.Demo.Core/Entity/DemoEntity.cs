using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Nankingcigar.Demo.Core.Entity
{
    public abstract class DemoEntity :
        FullAuditedEntity<long>,
        IPassivable
    {
        public virtual bool IsActive { get; set; }
    }
}