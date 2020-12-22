using LazyAbp.MessageKit;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyAbp.MessageKit.EntityFrameworkCore
{
    [DependsOn(
        typeof(MessageKitDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class MessageKitEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MessageKitDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Message, MessageRepository>();
                options.AddRepository<MessageToUser, MessageToUserRepository>();
            });
        }
    }
}
