using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.UI.Component
{
    public class ComponentMap : EntityTypeConfiguration<Core.Entity.UI.Component.Component>
    {
        public ComponentMap()
        {
            this.HasMany(e => e.ComponentModules)
                .WithRequired(e => e.Component)
                .HasForeignKey(e => e.ComponentId);
        }
    }
}
