using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.AspNet.Identity;
using Nankingcigar.Demo.Core.Entity.POCO.Module;
using Nankingcigar.Demo.Core.Entity.POCO.Role;
using Nankingcigar.Demo.Core.Entity.POCO.Route;

namespace Nankingcigar.Demo.Core.Entity.POCO.User
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

            CreatedRoles = new HashSet<POCO.Role.Role>();
            LastModifiedRoles = new HashSet<POCO.Role.Role>();
            DeletedRoles = new HashSet<POCO.Role.Role>();

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

            CreatedModules = new HashSet<Module.Module>();
            LastModifiedModules = new HashSet<Module.Module>();
            DeletedModules = new HashSet<Module.Module>();

            CreatedModuleRelationships = new HashSet<ModuleRelationship>();
            LastModifiedModuleRelationships = new HashSet<ModuleRelationship>();
            DeletedModuleRelationships = new HashSet<ModuleRelationship>();

            CreatedModuleComponents = new HashSet<ModuleComponent>();
            LastModifiedModuleComponents = new HashSet<ModuleComponent>();
            DeletedModuleComponents = new HashSet<ModuleComponent>();

            CreatedComponents = new HashSet<Component.Component>();
            LastModifiedComponents = new HashSet<Component.Component>();
            DeletedComponents = new HashSet<Component.Component>();

            CreatedRoutes = new HashSet<Route.Route>();
            LastModifiedRoutes = new HashSet<Route.Route>();
            DeletedRoutes = new HashSet<Route.Route>();

            CreatedRouteRelationships = new HashSet<RouteRelationship>();
            LastModifiedRouteRelationships = new HashSet<RouteRelationship>();
            DeletedRouteRelationships = new HashSet<RouteRelationship>();

            CreatedRoleRoutes = new HashSet<RoleRoute>();
            LastModifiedRoleRoutes = new HashSet<RoleRoute>();
            DeletedRoleRoutes = new HashSet<RoleRoute>();

            CreatedUserRoutes = new HashSet<UserRoute>();
            LastModifiedUserRoutes = new HashSet<UserRoute>();
            DeletedUserRoutes = new HashSet<UserRoute>();
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
        public ICollection<POCO.Role.Role> CreatedRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<POCO.Role.Role> LastModifiedRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<POCO.Role.Role> DeletedRoles { get; set; }


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


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Module.Module> CreatedModules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Module.Module> LastModifiedModules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Module.Module> DeletedModules { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ModuleRelationship> CreatedModuleRelationships { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ModuleRelationship> LastModifiedModuleRelationships { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ModuleRelationship> DeletedModuleRelationships { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ModuleComponent> CreatedModuleComponents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ModuleComponent> LastModifiedModuleComponents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ModuleComponent> DeletedModuleComponents { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Component.Component> CreatedComponents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Component.Component> LastModifiedComponents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Component.Component> DeletedComponents { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Route.Route> CreatedRoutes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Route.Route> LastModifiedRoutes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Route.Route> DeletedRoutes { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RouteRelationship> CreatedRouteRelationships { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RouteRelationship> LastModifiedRouteRelationships { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RouteRelationship> DeletedRouteRelationships { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RoleRoute> CreatedRoleRoutes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RoleRoute> LastModifiedRoleRoutes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RoleRoute> DeletedRoleRoutes { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserRoute> CreatedUserRoutes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserRoute> LastModifiedUserRoutes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserRoute> DeletedUserRoutes { get; set; }
    }
}