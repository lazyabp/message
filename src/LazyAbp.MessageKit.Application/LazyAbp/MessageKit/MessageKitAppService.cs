using LazyAbp.MessageKit.Localization;
using Volo.Abp.Application.Services;

namespace LazyAbp.MessageKit
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
