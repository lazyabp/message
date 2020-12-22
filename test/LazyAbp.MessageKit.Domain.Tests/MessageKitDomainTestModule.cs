using LazyAbp.MessageKit.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyAbp.MessageKit
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(MessageKitEntityFrameworkCoreTestModule)
        )]
    public class MessageKitDomainTestModule : AbpModule
    {
        
    }
}
