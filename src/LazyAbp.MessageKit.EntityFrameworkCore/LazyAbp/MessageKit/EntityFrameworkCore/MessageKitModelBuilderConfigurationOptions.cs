using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LazyAbp.MessageKit.EntityFrameworkCore
{
    public class MessageKitModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public MessageKitModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}