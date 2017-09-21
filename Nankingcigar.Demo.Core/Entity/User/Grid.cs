using Abp.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nankingcigar.Demo.Core.Entity.User
{
    [Table("UserGrid")]
    public class Grid : Entity<long>
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string DisplayName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public DateTime? LastLoginTime { get; set; }
    }
}