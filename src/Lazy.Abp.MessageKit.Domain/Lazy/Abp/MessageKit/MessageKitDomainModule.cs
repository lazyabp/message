using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Lazy.Abp.MessageKit
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(MessageKitDomainSharedModule)
    )]
    public class MessageKitDomainModule : AbpModule
    {

    }
}
