using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.MessageKit
{
    public interface IUserMessageRepository : IRepository<UserMessage, Guid>
    {
        Task<UserMessage> GetByIdAsync(
            Guid id, 
            bool includeDetails = true, 
            CancellationToken cancellationToken = default
        );

        Task<List<UserMessage>> GetByMessaggeIdAsync(
            Guid messageId, 
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            Guid? userId = null,
            bool? isReaded = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<UserMessage>> GetListAsync(
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            Guid? userId = null,
            bool? isReaded = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}