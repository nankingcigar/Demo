using System.Data.Entity.ModelConfiguration;
using Nankingcigar.Demo.Core.Entity.POCO.Module;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.POCO.Module
{
    internal class ModuleRelationshipMap : EntityTypeConfiguration<ModuleRelationship>
    {
        public ModuleRelationshipMap()
        {
            this.HasMany(t => t.Routes)
                .WithOptional(t => t.ModuleRelationship)
                .HasForeignKey(t => t.ModuleRelationshipId);
        }
    }
}