using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Nankingcigar.Demo.Core.Entity.POCO.Role
{
    [Table("RoleUser")]
    public sealed class RoleUser :
        DemoEntity,
        IFullAudited<User.User>
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        public POCO.Role.Role Role { get; set; }
        public User.User User { get; set; }

        public User.User CreatorUser { get; set; }
        public User.User LastModifierUser { get; set; }
        public User.User DeleterUser { get; set; }
    }
}