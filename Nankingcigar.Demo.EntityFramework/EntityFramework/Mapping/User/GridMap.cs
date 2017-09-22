using Nankingcigar.Demo.Core.Entity.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.User
{
    public class GridMap : EntityTypeConfiguration<Grid>
    {
        public GridMap()
        {
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}