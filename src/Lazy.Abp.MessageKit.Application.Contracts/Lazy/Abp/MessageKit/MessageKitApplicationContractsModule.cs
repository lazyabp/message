using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Lazy.Abp.MessageKit
{
    [DependsOn(
        typeof(MessageKitDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class MessageKitApplicationContractsModule : AbpModule
    {

    }
}
