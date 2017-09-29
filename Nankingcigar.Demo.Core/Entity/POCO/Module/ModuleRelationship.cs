using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Nankingcigar.Demo.Core.Entity.POCO.Module
{
    [Table("ModuleRelationship")]
    public sealed class ModuleRelationship :
        DemoEntity,
        IFullAudited<User.User>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModuleRelationship()
        {
            Routes = new HashSet<Route.Route>();
        }

        public long ParentId { get; set; }
        public long ChildId { get; set; }

        public POCO.Module.Module Parent { get; set; }
        public POCO.Module.Module Child { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Route.Route> Routes { get; set; }


        public User.User CreatorUser { get; set; }
        public User.User LastModifierUser { get; set; }
        public User.User DeleterUser { get; set; }
    }
}