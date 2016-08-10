using System.Data.Entity.Migrations;
using Novaetra.Backend.Entities;

namespace Novaetra.Backend.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EntityFramework.BackendDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "NovaetraBackend";
        }

        protected override void Seed(EntityFramework.BackendDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
            context.Users.AddOrUpdate(
                x => new { x.DisplayName, x.Email }, // AddOrUpdate based upon DisplayName and Email matching
                new User
                {
                    DisplayName = "Isaac Asimov",
                    Email = "isaac.asimov@gmail.com",
                    Account = new Account { IterationCount = 20000, PasswordHash = new byte[32 * 8], Salt = new byte[16 * 8] }
                },
                new User
                {
                    DisplayName = "George Orwell",
                    Email = "george.orwell@gmail.com",
                    Account = new Account { IterationCount = 20000, PasswordHash = new byte[32 * 8], Salt = new byte[16 * 8] }
                },
                new User
                {
                    DisplayName = "Douglas Adams",
                    Email = "douglas.adams@gmail.com",
                    Account = new Account { IterationCount = 20000, PasswordHash = new byte[32 * 8], Salt = new byte[16 * 8] }
                },
                new User
                {
                    DisplayName = "Thomas More",
                    Email = "thomas.more@gmail.com",
                    Account = new Account { IterationCount = 20000, PasswordHash = new byte[32 * 8], Salt = new byte[16 * 8] }
                }
                );
        }
    }
}
