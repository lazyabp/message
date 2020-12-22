using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.MessageKit
{
    public class MessageToUser : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; }

        public virtual Guid? UserId { get; protected set; }

        public virtual Guid MessageId { get; protected set; }

        public virtual bool IsReaded { get; protected set; }

        public virtual Message Message { get; set; }

        protected MessageToUser()
        {
        }

        public MessageToUser(Guid id, Guid messageId, Guid? tenantId, Guid? userId)
        {
            Id = id;
            MessageId = messageId;
            TenantId = tenantId;
            UserId = userId;
            IsReaded = false;
        }

        public void SetAsReaded(bool isReaded)
        {
            IsReaded = isReaded;
        }

        public MessageToUser(
            Guid id, 
            Guid? tenantId, 
            Guid? userId, 
            Guid messageId, 
            bool isReaded
        ) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            MessageId = messageId;
            IsReaded = isReaded;
        }
    }
}
