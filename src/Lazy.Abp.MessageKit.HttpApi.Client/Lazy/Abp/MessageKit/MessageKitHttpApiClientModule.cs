using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Lazy.Abp.MessageKit
{
    [DependsOn(
        typeof(MessageKitApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class MessageKitHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "MessageKit";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(MessageKitApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
