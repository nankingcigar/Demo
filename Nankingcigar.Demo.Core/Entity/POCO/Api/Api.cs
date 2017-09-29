using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Nankingcigar.Demo.Core.Entity.POCO.Role;
using Nankingcigar.Demo.Core.Entity.POCO.User;

namespace Nankingcigar.Demo.Core.Entity.POCO.Api
{
    [Table("Api")]
    public sealed class Api :
        DemoEntity,
        IFullAudited<User.User>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Api()
        {
            ApiRoles = new HashSet<RoleApi>();
            ApiUsers = new HashSet<UserApi>();
        }

        [Required]
        [StringLength(50)]
        public string Namespace { get; set; }

        [Required]
        [StringLength(20)]
        public string ClassName { get; set; }

        [Required]
        [StringLength(20)]
        public string MethodName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RoleApi> ApiRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserApi> ApiUsers { get; set; }


        public User.User CreatorUser { get; set; }
        public User.User LastModifierUser { get; set; }
        public User.User DeleterUser { get; set; }
    }
}