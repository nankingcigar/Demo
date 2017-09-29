using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.POCO.Route
{
    internal class RouteMap : EntityTypeConfiguration<Core.Entity.POCO.Route.Route>
    {
        public RouteMap()
        {
            this.HasMany(t => t.Parents)
                .WithRequired(t => t.Parent)
                .HasForeignKey(t => t.ParentId);
            this.HasMany(t => t.Children)
                .WithRequired(t => t.Child)
                .HasForeignKey(t => t.ChildId);
            this.HasMany(t => t.RouteRoles)
                .WithRequired(t => t.Route)
                .HasForeignKey(t => t.RouteId);
            this.HasMany(t => t.RouteUsers)
                .WithRequired(t => t.Route)
                .HasForeignKey(t => t.RouteId);
        }
    }
}