using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Nankingcigar.Demo.Core.Entity.UI.Module
{
    [Table("ModuleRelationship")]
    public class ModuleRelationship : Entity<long>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModuleRelationship()
        {
            Routes = new HashSet<Route.Route>();
        }

        public long ParentId { get; set; }
        public long ChildId { get; set; }

        public Module Parent { get; set; }
        public Module Child { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Route.Route> Routes { get; set; }
    }
}