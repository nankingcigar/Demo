using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.Role
{
    public class RoleMap : EntityTypeConfiguration<Core.Entity.Role.Role>
    {
        public RoleMap()
        {
            this.HasMany(t => t.RoleApis)
                .WithRequired(t => t.Role)
                .HasForeignKey(t => t.RoleId);

            this.HasMany(t => t.RoleUsers)
                .WithRequired(t => t.Role)
                .HasForeignKey(t => t.RoleId);
        }
    }
}