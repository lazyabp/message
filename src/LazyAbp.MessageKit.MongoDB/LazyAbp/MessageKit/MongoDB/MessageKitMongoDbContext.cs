using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LazyAbp.MessageKit.MongoDB
{
    [ConnectionStringName(MessageKitDbProperties.ConnectionStringName)]
    public class MessageKitMongoDbContext : AbpMongoDbContext, IMessageKitMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureMessageKit();
        }
    }
}