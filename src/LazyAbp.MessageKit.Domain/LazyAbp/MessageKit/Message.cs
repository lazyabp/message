using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.MessageKit
{
    public class Message : FullAuditedAggregateRoot<Guid>
    {
        [MaxLength(MessageConsts.MaxTypeNameLength)]
        public virtual string TypeName { get; protected set; }

        [MaxLength(MessageConsts.MaxTitleLength)]
        public virtual string Title { get; protected set; }

        public virtual string Body { get; protected set; }

        public virtual List<MessageToUser> MessageToUsers { get; set; }

        protected Message()
        {
        }

        public Message(
            Guid id, 
            string typeName,
            string title, 
            string body
        ) : base(id)
        {
            TypeName = typeName;
            Title = title;
            Body = body;

            MessageToUsers = new List<MessageToUser>();
        }

        public void Update(string typeName, string title, string body)
        {
            TypeName = typeName;
            Title = title;
            Body = body;
        }

        public void AddUser(Guid subId, Guid? userId, Guid? tenantId)
        {
            if (tenantId.HasValue && !MessageToUsers.Any(m => m.TenantId == tenantId))
            {
                MessageToUsers.Add(new MessageToUser(subId, Id, tenantId, userId));
            }
            else if (userId.HasValue && !MessageToUsers.Any(m => m.UserId == userId))
            {
                MessageToUsers.Add(new MessageToUser(subId, Id, tenantId, userId));
            }
        }
    }
}
