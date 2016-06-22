using Abp.Web.Mvc.Views;

namespace Hubo.Web.Views
{
    public abstract class HuboWebViewPageBase : HuboWebViewPageBase<dynamic>
    {

    }

    public abstract class HuboWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected HuboWebViewPageBase()
        {
            LocalizationSourceName = HuboConsts.LocalizationSourceName;
        }
    }
}