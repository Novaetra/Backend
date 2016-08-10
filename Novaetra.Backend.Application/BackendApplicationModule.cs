using System.Reflection;
using Abp.Modules;

namespace Novaetra.Backend
{
    [DependsOn(typeof(BackendCoreModule))]
    public class BackendApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            base.PostInitialize();
        }
    }
}
