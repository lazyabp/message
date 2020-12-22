using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using LazyAbp.MessageKit;

namespace LazyAbp.MessageKit.EntityFrameworkCore
{
    [ConnectionStringName(MessageKitDbProperties.ConnectionStringName)]
    public interface IMessageKitDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Message> Messages { get; set; }
        DbSet<MessageToUser> MessageToUsers { get; set; }
    }
}
