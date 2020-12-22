using Volo.Abp.Modularity;

namespace LazyAbp.MessageKit
{
    [DependsOn(
        typeof(MessageKitApplicationModule),
        typeof(MessageKitDomainTestModule)
        )]
    public class MessageKitApplicationTestModule : AbpModule
    {

    }
}
