using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Nankingcigar.Demo.Core.Entity.POCO.Module;
using Nankingcigar.Demo.Core.Entity.POCO.Role;
using Nankingcigar.Demo.Core.Entity.POCO.User;

namespace Nankingcigar.Demo.Core.Entity.POCO.Route
{
    [Table("Route")]
    public sealed class Route :
        DemoEntity,
        IFullAudited<User.User>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Route()
        {
            Parents = new HashSet<RouteRelationship>();
            Children = new HashSet<RouteRelationship>();
            RouteRoles = new HashSet<RoleRoute>();
            RouteUsers = new HashSet<UserRoute>();
        }

        [Required]
        [StringLength(50)]
        public string Path { get; set; }

        public long? ModuleRelationshipId { get; set; }
        public long? ModuleComponentId { get; set; }
        public long? ModuleId { get; set; }
        public string Config { get; set; }

        public ModuleRelationship ModuleRelationship { get; set; }
        public ModuleComponent ModuleComponent { get; set; }
        public POCO.Module.Module Module { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RouteRelationship> Parents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RouteRelationship> Children { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RoleRoute> RouteRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserRoute> RouteUsers { get; set; }


        public User.User CreatorUser { get; set; }
        public User.User LastModifierUser { get; set; }
        public User.User DeleterUser { get; set; }
    }
}