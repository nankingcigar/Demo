using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Nankingcigar.Demo.Core.Entity.Api;
using Nankingcigar.Demo.Core.Entity.User;

namespace Nankingcigar.Demo.Core.Entity.Permission
{
    [Table("Permission")]
    public sealed class Permission :
        DemoEntity,
        IFullAudited<Entity.User.User>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Permission()
        {
            UserPermissions = new HashSet<UserPermission>();
            ApiPermissions = new HashSet<ApiPermission>();
        }


        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public User.User CreatorUser { get; set; }
        public User.User LastModifierUser { get; set; }
        public User.User DeleterUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserPermission> UserPermissions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ApiPermission> ApiPermissions { get; set; }
    }
}
