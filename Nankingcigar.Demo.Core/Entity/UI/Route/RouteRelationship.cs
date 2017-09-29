using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nankingcigar.Demo.Core.Entity.UI.Route
{
    [Table("RouteRelationship")]
    public class RouteRelationship : Entity<long>
    {
        public long ParentId { get; set; }
        public long ChildId { get; set; }

        public Route Parent { get; set; }
        public Route Child { get; set; }
    }
}