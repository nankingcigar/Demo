using Nankingcigar.Demo.EntityFramework.EntityFramework;
using System.Data.Entity.Migrations;

namespace Nankingcigar.Demo.EntityFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Demo";
        }

        protected override void Seed(DemoDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}