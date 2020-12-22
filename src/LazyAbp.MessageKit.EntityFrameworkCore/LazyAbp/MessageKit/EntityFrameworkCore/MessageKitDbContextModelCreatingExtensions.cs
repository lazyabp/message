using LazyAbp.MessageKit;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LazyAbp.MessageKit.EntityFrameworkCore
{
    public static class MessageKitDbContextModelCreatingExtensions
    {
        public static void ConfigureMessageKit(
            this ModelBuilder builder,
            Action<MessageKitModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new MessageKitModelBuilderConfigurationOptions(
                MessageKitDbProperties.DbTablePrefix,
                MessageKitDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */


            builder.Entity<Message>(b =>
            {
                b.ToTable(options.TablePrefix + "Messages", options.Schema);
                b.ConfigureByConvention();

                //b.HasMany(q => q.MessageToUsers).WithOne().HasForeignKey(x => x.MessageId);
                /* Configure more properties here */
            });

            builder.Entity<MessageToUser>(b =>
            {
                b.ToTable(options.TablePrefix + "MessageToUsers", options.Schema);
                b.ConfigureByConvention();

                /* Configure more properties here */
            });
        }
    }
}
