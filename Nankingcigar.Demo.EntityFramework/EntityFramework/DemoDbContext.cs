using Abp.EntityFramework;
using Nankingcigar.Demo.Core.Entity;
using Nankingcigar.Demo.Core.Entity.Api;
using Nankingcigar.Demo.Core.Entity.Role;
using Nankingcigar.Demo.Core.Entity.User;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework
{
    public class DemoDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<User> User { get; set; }

        public virtual IDbSet<UserApi> UserApi { get; set; }

        public virtual IDbSet<Landing> Landing { get; set; }

        public virtual IDbSet<Grid> Grid { get; set; }

        public virtual IDbSet<AuditLog> AuditLog { get; set; }

        public virtual IDbSet<Role> Role { get; set; }

        public virtual IDbSet<RoleApi> RoleApi { get; set; }

        public virtual IDbSet<RoleUser> RoleUser { get; set; }

        public virtual IDbSet<Api> Api { get; set; }

        public virtual IDbSet<Core.Entity.UI.Module.Module> Module { get; set; }

        public virtual IDbSet<Core.Entity.UI.Module.ModuleComponent> ModuleComponent { get; set; }

        public virtual IDbSet<Core.Entity.UI.Module.ModuleRelationship> ModuleRelationship { get; set; }

        public virtual IDbSet<Core.Entity.UI.Component.Component> Component { get; set; }

        public virtual IDbSet<Core.Entity.UI.Route.Route> Route { get; set; }

        public virtual IDbSet<Core.Entity.UI.Route.RouteRelationship> RouteRelationship { get; set; }

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
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(entity => entity.BaseType != null && entity.BaseType.IsGenericType && entity.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }
    }
}