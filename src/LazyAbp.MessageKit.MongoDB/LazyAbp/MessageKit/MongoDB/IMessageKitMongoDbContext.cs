using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LazyAbp.MessageKit.MongoDB
{
    [ConnectionStringName(MessageKitDbProperties.ConnectionStringName)]
    public interface IMessageKitMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
