using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.MessageKit.MongoDB
{
    public class MessageKitMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public MessageKitMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}