using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Lazy.Abp.MessageKit;

namespace Lazy.Abp.MessageKit.EntityFrameworkCore
{
    [ConnectionStringName(MessageKitDbProperties.ConnectionStringName)]
    public interface IMessageKitDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Message> Messages { get; set; }
        DbSet<UserMessage> MessageToUsers { get; set; }
    }
}
