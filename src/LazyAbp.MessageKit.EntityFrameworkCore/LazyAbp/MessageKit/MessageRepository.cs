using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using LazyAbp.MessageKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.MessageKit
{
    public class MessageRepository : EfCoreRepository<IMessageKitDbContext, Message, Guid>, IMessageRepository
    {
        public MessageRepository(IDbContextProvider<IMessageKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Message> GetByIdAsync(
            Guid id, 
            bool includeDetails = true, 
            CancellationToken cancellationToken = default
        )
        {
            return await DbSet
                   .IncludeDetails(includeDetails)
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
            var query = GetListQuery(createdAfter, createdBefore, typeName, filter, false);

            var totalCount = await query.LongCountAsync(GetCancellationToken(cancellationToken));

            return totalCount;
        }

        public async Task<List<Message>> GetListAsync(
                string sorting = null,
                int maxResultCount = 10,
                int skipCount = 0,
                DateTime? createdAfter = null,
                DateTime? createdBefore = null,
                string typeName = null,
                string filter = null,
                bool withDetails = false,
                CancellationToken cancellationToken = default
            )
        {
            var query = GetListQuery(createdAfter, createdBefore, typeName, filter, withDetails);

            var messages = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return messages;
        }

        protected virtual IQueryable<Message> GetListQuery(
                DateTime? createdAfter = null,
                DateTime? createdBefore = null,
                string typeName = null,
                string filter = null,
                bool includeDetails = false
            )
        {
            return DbSet.AsNoTracking()
                .IncludeDetails(includeDetails)
                .WhereIf(createdAfter.HasValue, e => false || e.CreationTime >= createdAfter)
                .WhereIf(createdBefore.HasValue, e => false || e.CreationTime <= createdBefore)
                .WhereIf(!string.IsNullOrEmpty(typeName), e => false || e.TypeName == typeName)
                .WhereIf(
                    !string.IsNullOrEmpty(filter), 
                    e => false 
                    || e.Title.Contains(filter) 
                    || e.Body.Contains(filter)
                );
        }
    }
}