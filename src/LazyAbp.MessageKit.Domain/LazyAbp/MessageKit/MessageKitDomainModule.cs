using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace LazyAbp.MessageKit
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(MessageKitDomainSharedModule)
    )]
    public class MessageKitDomainModule : AbpModule
    {

    }
}
