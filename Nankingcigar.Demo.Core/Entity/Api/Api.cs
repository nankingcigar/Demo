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
    [Table("Api")]
    public sealed class Api : Entity<long>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Api()
        {
            ApiPermissions = new HashSet<ApiPermission>();
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
        public ICollection<ApiPermission> ApiPermissions { get; set; }
    }
}
