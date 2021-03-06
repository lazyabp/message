using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.MessageKit
{
    public interface IMessageRepository : IRepository<Message, Guid>
    {
        Task<Message> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string typeName = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<Message>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string typeName = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}