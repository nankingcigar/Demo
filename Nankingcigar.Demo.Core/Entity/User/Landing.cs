using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nankingcigar.Demo.Core.Entity.User
{
    [Table("vUserLanding")]
    public class Landing : Entity<long>
    {
        [StringLength(50)]
        public string Display { get; set; }
    }
}