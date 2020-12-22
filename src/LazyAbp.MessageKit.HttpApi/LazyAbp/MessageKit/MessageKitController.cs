using LazyAbp.MessageKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LazyAbp.MessageKit
{
    public abstract class MessageKitController : AbpController
    {
        protected MessageKitController()
        {
            LocalizationResource = typeof(MessageKitResource);
        }
    }
}
