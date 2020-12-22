using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using LazyAbp.MessageKit;

namespace LazyAbp.MessageKit.EntityFrameworkCore
{
    [ConnectionStringName(MessageKitDbProperties.ConnectionStringName)]
    public class MessageKitDbContext : AbpDbContext<MessageKitDbContext>, IMessageKitDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageToUser> MessageToUsers { get; set; }

        public MessageKitDbContext(DbContextOptions<MessageKitDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureMessageKit();
        }
    }
}
