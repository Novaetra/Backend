using Abp.Web.Mvc.Views;

namespace Novaetra.Backend.Web.Views
{
    public abstract class BackendWebViewPageBase : BackendWebViewPageBase<dynamic>
    {

    }

    public abstract class BackendWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected BackendWebViewPageBase()
        {
            LocalizationSourceName = BackendConsts.LocalizationSourceName;
        }
    }
}