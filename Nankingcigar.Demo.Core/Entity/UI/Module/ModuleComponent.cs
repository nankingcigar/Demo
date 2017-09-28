using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Nankingcigar.Demo.Core.Entity.UI.Module
{
    [Table("ModuleComponent")]
    public class ModuleComponent : Entity<long>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModuleComponent()
        {
            Routes = new HashSet<Route.Route>();
        }

        public long ModuleId { get; set; }
        public long ComponentId { get; set; }

        public Module Module { get; set; }
        public Component.Component Component { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Route.Route> Routes { get; set; }
    }
}