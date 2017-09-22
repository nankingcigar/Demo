using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nankingcigar.Demo.Core.Entity.Role
{
    [Table("RoleUser")]
    public sealed class RoleUser :
        DemoEntity,
        IFullAudited<User.User>
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        public Role Role { get; set; }
        public User.User User { get; set; }

        public User.User CreatorUser { get; set; }
        public User.User LastModifierUser { get; set; }
        public User.User DeleterUser { get; set; }
    }
}