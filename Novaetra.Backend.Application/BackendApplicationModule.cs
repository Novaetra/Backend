using System.Reflection;
using Abp.Modules;
using Abp.AutoMapper;
using Novaetra.Backend.Configuration;
using Novaetra.Backend.Authorization;

namespace Novaetra.Backend
{
    [DependsOn(typeof(BackendCoreModule), typeof(AbpAutoMapperModule))]
    public class BackendApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Authorization.Providers.Add<BackendAuthorizationProvider>();
            Configuration.Settings.Providers.Add<BackendSettingProvider>();
        }
    }
}
