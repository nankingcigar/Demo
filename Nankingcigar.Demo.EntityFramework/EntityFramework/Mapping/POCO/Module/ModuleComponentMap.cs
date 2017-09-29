using System.Data.Entity.ModelConfiguration;
using Nankingcigar.Demo.Core.Entity.POCO.Module;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.POCO.Module
{
    internal class ModuleComponentMap : EntityTypeConfiguration<ModuleComponent>
    {
        public ModuleComponentMap()
        {
            this.HasMany(t => t.Routes)
                .WithOptional(t => t.ModuleComponent)
                .HasForeignKey(t => t.ModuleComponentId);
        }
    }
}