using Lazy.Abp.MessageKit.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Lazy.Abp.MessageKit.Admin
{
    [DependsOn(
        typeof(MessageKitAdminApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class MessageKitAdminHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MessageKitAdminHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<MessageKitResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
