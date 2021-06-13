using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lazy.Abp.MessageKit.EntityFrameworkCore
{
    public class MessageKitHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<MessageKitHttpApiHostMigrationsDbContext>
    {
        public MessageKitHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<MessageKitHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("MessageKit"));

            return new MessageKitHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
