namespace Nankingcigar.Demo.Entity
{
    using System.Data.Entity;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.User1)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.CreatorUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.User11)
                .WithOptional(e => e.User3)
                .HasForeignKey(e => e.DeleterUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.User12)
                .WithOptional(e => e.User4)
                .HasForeignKey(e => e.LastModifierUserId);
        }
    }
}