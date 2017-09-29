using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nankingcigar.Demo.Core.Entity.View.User;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.View.User
{
    internal class GridMap : EntityTypeConfiguration<Grid>
    {
        public GridMap()
        {
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}