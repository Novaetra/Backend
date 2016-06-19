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
    }
}
