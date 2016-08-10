using System.Reflection;
using Abp.Modules;
using Abp.Zero;

namespace Novaetra.Backend
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class BackendCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
