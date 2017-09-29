using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.POCO.Component
{
    internal class ComponentMap : EntityTypeConfiguration<Core.Entity.POCO.Component.Component>
    {
        public ComponentMap()
        {
            this.HasMany(t => t.ComponentModules)
                .WithRequired(t => t.Component)
                .HasForeignKey(t => t.ComponentId);
        }
    }
}