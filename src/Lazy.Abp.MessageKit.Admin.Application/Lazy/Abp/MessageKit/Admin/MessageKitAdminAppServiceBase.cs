using Lazy.Abp.MessageKit.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.MessageKit.Admin
{
    public abstract class MessageKitAdminAppServiceBase : ApplicationService
    {
        protected MessageKitAdminAppServiceBase()
        {
            ObjectMapperContext = typeof(MessageKitAdminApplicationModule);
            LocalizationResource = typeof(MessageKitResource);
        }
    }
}
