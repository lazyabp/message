using Lazy.Abp.MessageKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.MessageKit
{
    public abstract class MessageKitController : AbpController
    {
        protected MessageKitController()
        {
            LocalizationResource = typeof(MessageKitResource);
        }
    }
}
