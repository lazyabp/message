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
    public class UserMessageRepository : EfCoreRepository<IMessageKitDbContext, UserMessage, Guid>, IUserMessageRepository
    {
        public UserMessageRepository(IDbContextProvider<IMessageKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<UserMessage>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(q => q.Message);
        }

        public async Task<UserMessage> GetByIdAsync(
            Guid id, 
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        )
        {
            return await (await GetQueryableAsync())
                   .IncludeIf(includeDetails, q => q.Message)
                   .Where(m => m.Id == id)
                   .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<UserMessage>> GetByMessaggeIdAsync(
            Guid messageId, 
            CancellationToken cancellationToken = default
        )
        {
            return await (await GetQueryableAsync())
                   .Where(m => m.MessageId == messageId)
                   .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            bool? isReaded = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, isReaded, filter);

            return await query
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<UserMessage>> GetListAsync(
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            Guid? userId = null,
            bool? isReaded = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, isReaded, filter);

            return await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual async Task<IQueryable<UserMessage>> GetListQuery(
            Guid? userId = null,
            bool? isReaded = null,
            string filter = null
        )
        {
            return (await GetQueryableAsync())
                .Include(q => q.Message)
                .WhereIf(userId.HasValue, e => false || e.UserId == userId)
                .WhereIf(isReaded.HasValue, e => false || e.IsReaded == isReaded)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Message.Title.Contains(filter)
                    || e.Message.Body.Contains(filter)
                );
        }
    }
}