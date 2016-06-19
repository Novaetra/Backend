﻿using Abp.EntityFramework;

namespace Novaetra.Backend.EntityFramework
{
    public class BackendDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

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
         *   This constructor is used by ABP to pass connection string defined in BackendDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of BackendDbContext since ABP automatically handles it.
         */
        public BackendDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
