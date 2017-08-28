using System.Data.Entity.Migrations;

namespace Nankingcigar.Demo.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Demo.EntityFramework.DemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Demo";
        }

        protected override void Seed(Demo.EntityFramework.DemoDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}