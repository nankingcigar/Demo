using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.UI.Component
{
    public class ComponentMap : EntityTypeConfiguration<Core.Entity.UI.Component.Component>
    {
        public ComponentMap()
        {
            this.HasMany(t => t.ComponentModules)
                .WithRequired(t => t.Component)
                .HasForeignKey(t => t.ComponentId);
        }
    }
}