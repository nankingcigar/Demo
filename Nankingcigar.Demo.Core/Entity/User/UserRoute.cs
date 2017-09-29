using Abp.Domain.Entities;
using Nankingcigar.Demo.Core.Entity.UI.Route;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nankingcigar.Demo.Core.Entity.User
{
    [Table("UserRoute")]
    public sealed class UserRoute : Entity<long>
    {
        public long UserId { get; set; }
        public long RouteId { get; set; }
        public bool HasPermission { get; set; }

        public User User { get; set; }
        public Route Route { get; set; }
    }
}