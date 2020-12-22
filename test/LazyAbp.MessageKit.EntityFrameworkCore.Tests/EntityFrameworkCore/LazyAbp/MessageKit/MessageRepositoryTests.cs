using System;
using System.Threading.Tasks;
using LazyAbp.MessageKit;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace LazyAbp.MessageKit.EntityFrameworkCore.LazyAbp.MessageKit
{
    public class MessageRepositoryTests : MessageKitEntityFrameworkCoreTestBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessageRepositoryTests()
        {
            _messageRepository = GetRequiredService<IMessageRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
