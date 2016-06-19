using System.Reflection;
using Abp.Modules;

namespace Novaetra.Backend
{
    public class BackendCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
