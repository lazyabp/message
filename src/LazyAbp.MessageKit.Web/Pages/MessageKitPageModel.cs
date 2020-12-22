using LazyAbp.MessageKit.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace LazyAbp.MessageKit.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class MessageKitPageModel : AbpPageModel
    {
        protected MessageKitPageModel()
        {
            LocalizationResourceType = typeof(MessageKitResource);
            ObjectMapperContext = typeof(MessageKitWebModule);
        }
    }
}