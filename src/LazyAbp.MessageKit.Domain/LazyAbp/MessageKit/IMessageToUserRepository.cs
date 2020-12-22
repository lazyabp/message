using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LazyAbp.MessageKit
{
    public interface IMessageToUserRepository : IRepository<MessageToUser, Guid>
    {
        Task<MessageToUser> GetByIdAsync(
            Guid id, 
            bool includeDetails = true, 
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            Guid? userId = null,
            bool? isReaded = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<List<MessageToUser>> GetListAsync(            
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            Guid? userId = null,
            bool? isReaded = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );
    }
}