using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace Nankingcigar.Demo.Core.Entity.User
{
    [Table("UserPermission")]
    public sealed class UserPermission :
        DemoEntity,
        IFullAudited<User>
    {
        public long UserId { get; set; }
        public long PermissionId { get; set; }

        public Permission.Permission Permission { get; set; }
        public User User { get; set; }

        public User CreatorUser { get; set; }
        public User LastModifierUser { get; set; }
        public User DeleterUser { get; set; }
    }
}
