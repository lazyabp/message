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
    public class MessageToUserRepository : EfCoreRepository<IMessageKitDbContext, MessageToUser, Guid>, IMessageToUserRepository
    {
        public MessageToUserRepository(IDbContextProvider<IMessageKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<MessageToUser> GetByIdAsync(
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
            Guid? userId = null,
            bool? isReaded = null,
            string filter = null,
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        )
        {
            var query = GetListQuery(userId, isReaded, filter, includeDetails);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<MessageToUser>> GetListAsync(
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            Guid? userId = null,
            bool? isReaded = null,
            string filter = null,
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        )
        {
            var query = GetListQuery(userId, isReaded, filter, includeDetails);

            return await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<MessageToUser> GetListQuery(
            Guid? userId = null,
            bool? isReaded = null,
            string filter = null,
            bool includeDetails = true
        )
        {
            return DbSet.AsNoTracking()
                .IncludeDetails(includeDetails)
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