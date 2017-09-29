using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.AspNet.Identity;
using Nankingcigar.Demo.Core.Entity.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nankingcigar.Demo.Core.Entity.User
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
            UserAuditLogs = new HashSet<AuditLog>();
            ImpersonatorAuditLogs = new HashSet<AuditLog>();
            UserRoles = new HashSet<RoleUser>();
            UserApis = new HashSet<UserApi>();
            UserRoutes = new HashSet<UserRoute>();

            CreatedUsers = new HashSet<User>();
            LastModifiedUsers = new HashSet<User>();
            DeletedUsers = new HashSet<User>();

            CreatedRoles = new HashSet<Role.Role>();
            LastModifiedRoles = new HashSet<Role.Role>();
            DeletedRoles = new HashSet<Role.Role>();

            CreatedApis = new HashSet<Api.Api>();
            LastModifiedApis = new HashSet<Api.Api>();
            DeletedApis = new HashSet<Api.Api>();

            CreatedRoleApis = new HashSet<RoleApi>();
            LastModifiedRoleApis = new HashSet<RoleApi>();
            DeletedRoleApis = new HashSet<RoleApi>();

            CreatedRoleUsers = new HashSet<RoleUser>();
            LastModifiedRoleUsers = new HashSet<RoleUser>();
            DeletedRoleUsers = new HashSet<RoleUser>();

            CreatedUserApis = new HashSet<UserApi>();
            LastModifiedUserApis = new HashSet<UserApi>();
            DeletedUserApis = new HashSet<UserApi>();
        }

        public bool IsActive { get; set; }
        public User CreatorUser { get; set; }
        public User LastModifierUser { get; set; }
        public User DeleterUser { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Display { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [StringLength(50)]
        public string AuthenticationSource { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<AuditLog> UserAuditLogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<AuditLog> ImpersonatorAuditLogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RoleUser> UserRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserApi> UserApis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserRoute> UserRoutes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<User> CreatedUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<User> LastModifiedUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<User> DeletedUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Role.Role> CreatedRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Role.Role> LastModifiedRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Role.Role> DeletedRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Api.Api> CreatedApis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Api.Api> LastModifiedApis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Api.Api> DeletedApis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RoleApi> CreatedRoleApis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RoleApi> LastModifiedRoleApis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RoleApi> DeletedRoleApis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RoleUser> CreatedRoleUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RoleUser> LastModifiedRoleUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RoleUser> DeletedRoleUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserApi> CreatedUserApis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserApi> LastModifiedUserApis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserApi> DeletedUserApis { get; set; }
    }
}