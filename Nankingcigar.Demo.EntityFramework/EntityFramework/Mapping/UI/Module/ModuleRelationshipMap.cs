using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.UI.Module
{
    public class ModuleRelationshipMap : EntityTypeConfiguration<Core.Entity.UI.Module.ModuleRelationship>
    {
        public ModuleRelationshipMap()
        {
            this.HasMany(t => t.Routes)
                .WithOptional(t => t.ModuleRelationship)
                .HasForeignKey(t => t.ModuleRelationshipId);
        }
    }
}