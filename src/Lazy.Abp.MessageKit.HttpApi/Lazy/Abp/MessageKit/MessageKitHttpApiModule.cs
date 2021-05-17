using Localization.Resources.AbpUi;
using Lazy.Abp.MessageKit.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Lazy.Abp.MessageKit
{
    [DependsOn(
        typeof(MessageKitApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class MessageKitHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MessageKitHttpApiModule).Assembly);
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
