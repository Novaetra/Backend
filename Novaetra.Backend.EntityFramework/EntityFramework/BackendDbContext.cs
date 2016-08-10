using System.Data.Entity;
using Abp.EntityFramework;
using Abp.Zero.EntityFramework;
using Novaetra.Backend.MultiTenancy;
using Novaetra.Backend.Authorization;
using Novaetra.Backend.Users;
using System.Data.Common;

namespace Novaetra.Backend.EntityFramework
{
    public class BackendDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        // Define an IDbSet for each Entity...
        // E.g.: public virtual IDbSet<Entity> Entities { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public BackendDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ModuleZeroSampleProjectDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ModuleZeroSampleProjectDbContext since ABP automatically handles it.
         */
        public BackendDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //public BackendDbContext (DbConnection connection)
        //    : base(connection, true)
        //{

        //}
    }
}
