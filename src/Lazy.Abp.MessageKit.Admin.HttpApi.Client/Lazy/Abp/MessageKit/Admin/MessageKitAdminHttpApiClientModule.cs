using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Lazy.Abp.MessageKit.Admin
{
    [DependsOn(
        typeof(MessageKitAdminApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class MessageKitAdminHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(MessageKitAdminApplicationContractsModule).Assembly,
                MessageKitAdminRemoteServiceConsts.RemoteServiceName);
        }
    }
}
