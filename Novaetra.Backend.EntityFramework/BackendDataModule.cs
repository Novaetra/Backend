using System.Data.Entity;
using System.Reflection;
using Novaetra.Backend.EntityFramework;
using Abp.Zero.EntityFramework;
using Abp.Modules;

namespace Novaetra.Backend
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(BackendCoreModule))]
    public class BackendDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
