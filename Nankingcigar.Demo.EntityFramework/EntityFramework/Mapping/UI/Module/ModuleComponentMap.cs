using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.UI.Module
{
    public class ModuleComponentMap : EntityTypeConfiguration<Core.Entity.UI.Module.ModuleComponent>
    {
        public ModuleComponentMap()
        {
            this.HasMany(t => t.Routes)
                .WithOptional(t => t.ModuleComponent)
                .HasForeignKey(t => t.ModuleComponentId);
        }
    }
}