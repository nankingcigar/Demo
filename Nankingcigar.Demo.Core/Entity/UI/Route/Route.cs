using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Nankingcigar.Demo.Core.Entity.UI.Module;

namespace Nankingcigar.Demo.Core.Entity.UI.Route
{
    [Table("Route")]
    public class Route : Entity<long>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Route()
        {
            Parents = new HashSet<RouteRelationship>();
            Children = new HashSet<RouteRelationship>();
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
        public Module.Module Module { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RouteRelationship> Parents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RouteRelationship> Children { get; set; }

    }
}