using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Nankingcigar.Demo.Core.Entity.POCO.Route
{
    [Table("RouteRelationship")]
    public sealed class RouteRelationship :
        DemoEntity,
        IFullAudited<User.User>
    {
        public long ParentId { get; set; }
        public long ChildId { get; set; }

        public POCO.Route.Route Parent { get; set; }
        public POCO.Route.Route Child { get; set; }


        public User.User CreatorUser { get; set; }
        public User.User LastModifierUser { get; set; }
        public User.User DeleterUser { get; set; }
    }
}