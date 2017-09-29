using Abp.Domain.Entities;
using Nankingcigar.Demo.Core.Entity.UI.Route;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nankingcigar.Demo.Core.Entity.Role
{
    [Table("RoleRoute")]
    public sealed class RoleRoute : Entity<long>
    {
        public long RoleId { get; set; }
        public long RouteId { get; set; }
        public bool HasPermission { get; set; }

        public Role Role { get; set; }
        public Route Route { get; set; }
    }
}