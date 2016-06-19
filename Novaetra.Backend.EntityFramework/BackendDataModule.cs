using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Novaetra.Backend.EntityFramework;

namespace Novaetra.Backend
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(BackendCoreModule))]
    public class BackendDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<BackendDbContext>(null);
        }
    }
}
