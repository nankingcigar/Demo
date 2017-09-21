using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Nankingcigar.Demo.Core.Entity.User;
using Abp.Domain.Entities;

namespace Nankingcigar.Demo.Core.Entity.Api
{
    [Table("ApiPermission")]
    public sealed class ApiPermission : Entity<long>
    {
        public long ApiId { get; set; }
        public long PermissionId { get; set; }

        public Permission.Permission Permission { get; set; }
        public Api Api { get; set; }
    }
}
