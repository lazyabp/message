using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Lazy.Abp.MessageKit.Admin
{
    [DependsOn(
        typeof(MessageKitApplicationContractsModule),
        typeof(MessageKitDomainSharedModule)
        )]
    public class MessageKitAdminApplicationContractsModule : AbpModule
    {
    }
}
