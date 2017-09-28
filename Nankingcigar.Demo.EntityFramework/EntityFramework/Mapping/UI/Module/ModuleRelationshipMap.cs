using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.UI.Module
{
    public class ModuleRelationshipMap : EntityTypeConfiguration<Core.Entity.UI.Module.ModuleRelationship>
    {
        public ModuleRelationshipMap()
        {
            this.HasMany(e => e.Routes)
                .WithOptional(e => e.ModuleRelationship)
                .HasForeignKey(e => e.ModuleRelationshipId);
        }
    }
}
