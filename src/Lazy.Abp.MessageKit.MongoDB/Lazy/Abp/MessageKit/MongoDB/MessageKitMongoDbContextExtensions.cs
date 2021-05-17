using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.MessageKit.MongoDB
{
    public static class MessageKitMongoDbContextExtensions
    {
        public static void ConfigureMessageKit(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new MessageKitMongoModelBuilderConfigurationOptions(
                MessageKitDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}