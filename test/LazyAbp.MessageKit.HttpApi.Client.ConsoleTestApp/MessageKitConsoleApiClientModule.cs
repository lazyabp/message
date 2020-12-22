using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace LazyAbp.MessageKit
{
    [DependsOn(
        typeof(MessageKitHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MessageKitConsoleApiClientModule : AbpModule
    {
        
    }
}
