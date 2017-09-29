using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Nankingcigar.Demo.Core.Entity.POCO.User
{
    [Table("UserRoute")]
    public sealed class UserRoute :
        DemoEntity,
        IFullAudited<POCO.User.User>
    {
        public long UserId { get; set; }
        public long RouteId { get; set; }
        public bool HasPermission { get; set; }

        public POCO.User.User User { get; set; }
        public Route.Route Route { get; set; }


        public POCO.User.User CreatorUser { get; set; }
        public POCO.User.User LastModifierUser { get; set; }
        public POCO.User.User DeleterUser { get; set; }
    }
}