﻿using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nankingcigar.Demo.Core.Entity.Role
{
    [Table("RoleApi")]
    public sealed class RoleApi :
        DemoEntity,
        IFullAudited<User.User>
    {
        public long ApiId { get; set; }
        public long RoleId { get; set; }

        public Role Role { get; set; }
        public Api.Api Api { get; set; }

        public User.User CreatorUser { get; set; }
        public User.User LastModifierUser { get; set; }
        public User.User DeleterUser { get; set; }
    }
}