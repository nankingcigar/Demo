using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

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