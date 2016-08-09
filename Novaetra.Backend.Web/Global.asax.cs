using System;
using Abp.Web;
using Castle.Facilities.Logging;
using Abp.Dependency;

namespace Novaetra.Backend.Web
{
    public class MvcApplication : AbpWebApplication<BackendWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
        }
    }
}
