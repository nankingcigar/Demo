using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.UI.Module
{
    public class ModuleComponentMap : EntityTypeConfiguration<Core.Entity.UI.Module.ModuleComponent>
    {
        public ModuleComponentMap()
        {
            this.HasMany(e => e.Routes)
                .WithOptional(e => e.ModuleComponent)
                .HasForeignKey(e => e.ModuleComponentId);
        }
    }
}
