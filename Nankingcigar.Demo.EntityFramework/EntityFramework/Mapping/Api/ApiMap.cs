using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.Api
{
    public class ApiMap : EntityTypeConfiguration<Core.Entity.Api.Api>
    {
        public ApiMap()
        {
            this.HasMany(t => t.ApiRoles)
                .WithRequired(t => t.Api)
                .HasForeignKey(t => t.ApiId);

            this.HasMany(t => t.ApiUsers)
                .WithRequired(t => t.Api)
                .HasForeignKey(t => t.ApiId);
        }
    }
}