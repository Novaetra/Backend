using Abp.Application.Services;

namespace Novaetra.Backend
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class BackendAppServiceBase : ApplicationService
    {
        protected BackendAppServiceBase()
        {
            LocalizationSourceName = BackendConsts.LocalizationSourceName;
        }
    }
}