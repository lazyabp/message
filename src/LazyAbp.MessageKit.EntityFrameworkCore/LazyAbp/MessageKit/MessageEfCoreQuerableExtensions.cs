using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.MessageKit
{
    public static class MessageEfCoreQueryableExtensions
    {
        public static IQueryable<Message> IncludeDetails(this IQueryable<Message> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                 .Include(x => x.MessageToUsers);
        }
    }
}