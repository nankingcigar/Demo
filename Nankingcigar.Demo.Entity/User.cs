namespace Nankingcigar.Demo.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            User1 = new HashSet<User>();
            User11 = new HashSet<User>();
            User12 = new HashSet<User>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(50)]
        public string DisplayName { get; set; }

        [StringLength(50)]
        public string AuthenticationSource { get; set; }

        public DateTimeOffset? LastLoginTime { get; set; }

        public bool? IsActive { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTimeOffset? CreationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public DateTimeOffset? LastModificationTime { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTimeOffset? DeletionTime { get; set; }

        public bool? IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User1 { get; set; }

        public virtual User User2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User11 { get; set; }

        public virtual User User3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User12 { get; set; }

        public virtual User User4 { get; set; }
    }
}