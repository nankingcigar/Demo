using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Nankingcigar.Demo.Core.Entity.POCO.Role
{
    [Table("RoleRoute")]
    public sealed class RoleRoute :
        DemoEntity,
        IFullAudited<User.User>
    {
        public long RoleId { get; set; }
        public long RouteId { get; set; }
        public bool HasPermission { get; set; }

        public Role Role { get; set; }
        public Route.Route Route { get; set; }


        public User.User CreatorUser { get; set; }
        public User.User LastModifierUser { get; set; }
        public User.User DeleterUser { get; set; }
    }
}