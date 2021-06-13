using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.MessageKit.EntityFrameworkCore
{
    public class MessageKitHttpApiHostMigrationsDbContext : AbpDbContext<MessageKitHttpApiHostMigrationsDbContext>
    {
        public MessageKitHttpApiHostMigrationsDbContext(DbContextOptions<MessageKitHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureMessageKit();
        }
    }
}
