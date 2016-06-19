using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace Novaetra.Backend
{
    [DependsOn(typeof(AbpWebApiModule), typeof(BackendApplicationModule))]
    public class BackendWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(BackendApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
