using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Nankingcigar.Demo.Core.Entity.POCO.User
{
    [Table("UserApi")]
    public sealed class UserApi :
        DemoEntity,
        IFullAudited<POCO.User.User>
    {
        public long UserId { get; set; }
        public long ApiId { get; set; }
        public bool HasPermission { get; set; }

        public Api.Api Api { get; set; }
        public POCO.User.User User { get; set; }


        public POCO.User.User CreatorUser { get; set; }
        public POCO.User.User LastModifierUser { get; set; }
        public POCO.User.User DeleterUser { get; set; }
    }
}