using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.POCO.Module
{
    internal sealed class ModuleMap : EntityTypeConfiguration<Core.Entity.POCO.Module.Module>
    {
        public ModuleMap()
        {
            this.HasMany(t => t.Parents)
                .WithRequired(t => t.Parent)
                .HasForeignKey(t => t.ParentId);
            this.HasMany(t => t.Children)
                .WithRequired(t => t.Child)
                .HasForeignKey(t => t.ChildId);
            this.HasMany(t => t.ModuleComponents)
                .WithRequired(t => t.Module)
                .HasForeignKey(t => t.ModuleId);
            this.HasMany(t => t.Routes)
                .WithOptional(t => t.Module)
                .HasForeignKey(t => t.ModuleId);
        }
    }
}