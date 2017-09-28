using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Nankingcigar.Demo.Core.Entity.UI.Module;

namespace Nankingcigar.Demo.Core.Entity.UI.Component
{
    [Table("Component")]
    public class Component : Entity<long>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Component()
        {
            ComponentModules = new HashSet<ModuleComponent>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ModuleComponent> ComponentModules { get; set; }
    }
}