using Abp.Web.Mvc.Controllers;

namespace Novaetra.Backend.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class BackendControllerBase : AbpController
    {
        protected BackendControllerBase()
        {
            LocalizationSourceName = BackendConsts.LocalizationSourceName;
        }
    }
}