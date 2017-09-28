using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.UI.Route
{
    public class RouteMap : EntityTypeConfiguration<Core.Entity.UI.Route.Route>
    {
        public RouteMap()
        {
            this.HasMany(e => e.Parents)
                .WithRequired(e => e.Parent)
                .HasForeignKey(e => e.ParentId);
            this.HasMany(e => e.Children)
                .WithRequired(e => e.Child)
                .HasForeignKey(e => e.ChildId);
        }
    }
}
