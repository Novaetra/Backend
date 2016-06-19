using System.Data.Entity.Migrations;

namespace Novaetra.Backend.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Backend.EntityFramework.BackendDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Backend";
        }

        protected override void Seed(Backend.EntityFramework.BackendDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
