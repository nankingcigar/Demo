using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Nankingcigar.Demo.Core.Entity.POCO.Module
{
    [Table("ModuleComponent")]
    public sealed class ModuleComponent :
        DemoEntity,
        IFullAudited<User.User>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModuleComponent()
        {
            Routes = new HashSet<Route.Route>();
        }

        public long ModuleId { get; set; }
        public long ComponentId { get; set; }

        public POCO.Module.Module Module { get; set; }
        public Component.Component Component { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Route.Route> Routes { get; set; }


        public User.User CreatorUser { get; set; }
        public User.User LastModifierUser { get; set; }
        public User.User DeleterUser { get; set; }
    }
}