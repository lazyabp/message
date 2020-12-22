using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace LazyAbp.MessageKit.Admin
{
    [DependsOn(typeof(MessageKitDomainSharedModule))]
    public class MessageKitAdminApplicationContractsModule : AbpModule
    {
    }
}
