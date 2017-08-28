using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nankingcigar.Demo.Core.Entity
{
    [Table("User")]
    public sealed class User :
        FullAuditedEntity<long>,
        IPassivable,
        IFullAudited<User>,
        IUser<long>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            CreatedUsers = new HashSet<User>();
            LastModifiedUsers = new HashSet<User>();
            DeletedUsers = new HashSet<User>();
        }

        public bool IsActive { get; set; }
        public User CreatorUser { get; set; }
        public User LastModifierUser { get; set; }
        public User DeleterUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<User> CreatedUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<User> LastModifiedUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<User> DeletedUsers { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(50)]
        public string DisplayName { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [StringLength(50)]
        public string AuthenticationSource { get; set; }
    }
}