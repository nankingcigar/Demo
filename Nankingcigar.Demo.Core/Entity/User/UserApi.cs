using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nankingcigar.Demo.Core.Entity.User
{
    [Table("UserApi")]
    public sealed class UserApi :
        DemoEntity,
        IFullAudited<User>
    {
        public long UserId { get; set; }
        public long ApiId { get; set; }
        public bool HasPermission { get; set; }

        public Api.Api Api { get; set; }
        public User User { get; set; }

        public User CreatorUser { get; set; }
        public User LastModifierUser { get; set; }
        public User DeleterUser { get; set; }
    }
}