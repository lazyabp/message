using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.MessageKit
{
    public static class MessageToUserEfCoreQueryableExtensions
    {
        public static IQueryable<MessageToUser> IncludeDetails(this IQueryable<MessageToUser> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                 .Include(x => x.Message);
        }
    }
}