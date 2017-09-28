using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.UI.Module
{
    public class ModuleMap : EntityTypeConfiguration<Core.Entity.UI.Module.Module>
    {
        public ModuleMap()
        {
            this.HasMany(e => e.Parents)
                .WithRequired(e => e.Parent)
                .HasForeignKey(e => e.ParentId);
            this.HasMany(e => e.Children)
                .WithRequired(e => e.Child)
                .HasForeignKey(e => e.ChildId);
            this.HasMany(e => e.ModuleComponents)
                .WithRequired(e => e.Module)
                .HasForeignKey(e => e.ModuleId);
            this.HasMany(e => e.Routes)
                .WithOptional(e => e.Module)
                .HasForeignKey(e => e.ModuleId);
        }
    }
}
