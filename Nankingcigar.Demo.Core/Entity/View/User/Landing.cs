using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Nankingcigar.Demo.Core.Entity.View.User
{
    [Table("vUserLanding")]
    public class Landing : Entity<long>
    {
        [StringLength(50)]
        public string Display { get; set; }
    }
}