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
    [Table("UserLanding")]
    public class Landing : Entity<long>
    {
        [StringLength(50)]
        public string DisplayName { get; set; }
    }
}