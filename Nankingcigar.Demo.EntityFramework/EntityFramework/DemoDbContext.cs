using Abp.EntityFramework;
using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.Core.Entity.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using Nankingcigar.Demo.Core.Entity.Api;
using Nankingcigar.Demo.Core.Entity.Permission;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework
{
    public class DemoDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Landing> UserLandings { get; set; }

        public virtual IDbSet<Grid> UserGrids { get; set; }

        public virtual IDbSet<UserPermission> UserPermissions { get; set; }

        public virtual IDbSet<AuditLog> Logs { get; set; }

        public virtual IDbSet<Permission> Permissions { get; set; }

        public virtual IDbSet<Api> Api { get; set; }
        public virtual IDbSet<ApiPermission> ApiPermissions { get; set; }

        /* NOTE:
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public DemoDbContext()
            : base("Default")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in DemoDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of DemoDbContext since ABP automatically handles it.
         */

        public DemoDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        //This constructor is used in tests
        public DemoDbContext(DbConnection existingConnection)
            : base(existingConnection, false)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DemoDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CreatedUsers)
                .WithOptional(e => e.CreatorUser)
                .HasForeignKey(e => e.CreatorUserId);
            modelBuilder.Entity<User>()
                .HasMany(e => e.LastModifiedUsers)
                .WithOptional(e => e.LastModifierUser)
                .HasForeignKey(e => e.LastModifierUserId);
            modelBuilder.Entity<User>()
                .HasMany(e => e.DeletedUsers)
                .WithOptional(e => e.DeleterUser)
                .HasForeignKey(e => e.DeleterUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserAuditLogs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);
            modelBuilder.Entity<User>()
                .HasMany(e => e.ImpersonatorAuditLogs)
                .WithOptional(e => e.Impersonator)
                .HasForeignKey(e => e.ImpersonatorUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CreatedPermissions)
                .WithOptional(e => e.CreatorUser)
                .HasForeignKey(e => e.CreatorUserId);
            modelBuilder.Entity<User>()
                .HasMany(e => e.LastModifiedPermissions)
                .WithOptional(e => e.LastModifierUser)
                .HasForeignKey(e => e.LastModifierUserId);
            modelBuilder.Entity<User>()
                .HasMany(e => e.DeletedPermissions)
                .WithOptional(e => e.DeleterUser)
                .HasForeignKey(e => e.DeleterUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserPermissions)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);
            modelBuilder.Entity<User>()
                .HasMany(e => e.CreatedUserPermissions)
                .WithOptional(e => e.CreatorUser)
                .HasForeignKey(e => e.CreatorUserId);
            modelBuilder.Entity<User>()
                .HasMany(e => e.LastModifiedUserPermissions)
                .WithOptional(e => e.LastModifierUser)
                .HasForeignKey(e => e.LastModifierUserId);
            modelBuilder.Entity<User>()
                .HasMany(e => e.DeletedUserPermissions)
                .WithOptional(e => e.DeleterUser)
                .HasForeignKey(e => e.DeleterUserId);

            modelBuilder.Entity<Landing>()
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Grid>()
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.UserPermissions)
                .WithRequired(e => e.Permission)
                .HasForeignKey(e => e.PermissionId);
            modelBuilder.Entity<Permission>()
                .HasMany(e => e.ApiPermissions)
                .WithRequired(e => e.Permission)
                .HasForeignKey(e => e.PermissionId);

            modelBuilder.Entity<Api>()
                .HasMany(e => e.ApiPermissions)
                .WithRequired(e => e.Api)
                .HasForeignKey(e => e.ApiId);

        }
    }
}