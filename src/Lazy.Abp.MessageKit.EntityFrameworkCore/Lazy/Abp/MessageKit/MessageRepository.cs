using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Lazy.Abp.MessageKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.MessageKit
{
    public class MessageRepository : EfCoreRepository<IMessageKitDbContext, Message, Guid>, IMessageRepository
    {
        public MessageRepository(IDbContextProvider<IMessageKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Message> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default
        )
        {
            return await (await GetQueryableAsync())
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string typeName = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(createdAfter, createdBefore, typeName, filter);

            return await query
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Message>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string typeName = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(createdAfter, createdBefore, typeName, filter);

            return await query
                .OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual async Task<IQueryable<Message>> GetListQuery(
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string typeName = null,
            string filter = null
        )
        {
            return (await GetQueryableAsync())
                .WhereIf(createdAfter.HasValue, e => e.CreationTime >= createdAfter.Value.Date)
                .WhereIf(createdBefore.HasValue, e => e.CreationTime < createdBefore.Value.AddDays(1).Date)
                .WhereIf(!string.IsNullOrEmpty(typeName), e => e.TypeName == typeName)
                .WhereIf(
                    !string.IsNullOrEmpty(filter), 
                    e => false 
                    || e.Title.Contains(filter) 
                    || e.Body.Contains(filter)
                );
        }
    }
}