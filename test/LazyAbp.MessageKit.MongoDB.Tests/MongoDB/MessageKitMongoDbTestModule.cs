using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace LazyAbp.MessageKit.MongoDB
{
    [DependsOn(
        typeof(MessageKitTestBaseModule),
        typeof(MessageKitMongoDbModule)
        )]
    public class MessageKitMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/') +
                                   "Db_" +
                                    Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}