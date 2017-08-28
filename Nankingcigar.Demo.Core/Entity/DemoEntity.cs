using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Nankingcigar.Demo.Core.Entity
{
    public abstract class DemoEntity :
        FullAuditedEntity<long>,
        IPassivable,
        IFullAudited<User>
    {
        public virtual bool IsActive { get; set; }
        public virtual User CreatorUser { get; set; }
        public virtual User LastModifierUser { get; set; }
        public virtual User DeleterUser { get; set; }
    }
}