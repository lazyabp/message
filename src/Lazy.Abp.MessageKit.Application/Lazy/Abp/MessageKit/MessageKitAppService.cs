using Lazy.Abp.MessageKit.Localization;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.MessageKit
{
    public abstract class MessageKitAppService : ApplicationService
    {
        protected MessageKitAppService()
        {
            LocalizationResource = typeof(MessageKitResource);
            ObjectMapperContext = typeof(MessageKitApplicationModule);
        }
    }
}
