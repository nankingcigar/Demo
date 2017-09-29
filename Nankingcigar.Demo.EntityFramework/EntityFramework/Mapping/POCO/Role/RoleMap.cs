using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.POCO.Role
{
    internal class RoleMap : EntityTypeConfiguration<Core.Entity.POCO.Role.Role>
    {
        public RoleMap()
        {
            this.HasMany(t => t.RoleApis)
                .WithRequired(t => t.Role)
                .HasForeignKey(t => t.RoleId);

            this.HasMany(t => t.RoleUsers)
                .WithRequired(t => t.Role)
                .HasForeignKey(t => t.RoleId);

            this.HasMany(t => t.RoleRoutes)
                .WithRequired(t => t.Role)
                .HasForeignKey(t => t.RoleId);
        }
    }
}