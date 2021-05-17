using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.MessageKit
{
    public class UserMessage : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; }

        public virtual Guid? UserId { get; protected set; }

        public virtual Guid MessageId { get; protected set; }

        public virtual bool IsReaded { get; protected set; }

        public virtual Message Message { get; set; }

        protected UserMessage()
        {
        }

        public UserMessage(Guid id, Guid messageId, Guid? tenantId, Guid? userId) : base(id)
        {
            MessageId = messageId;
            TenantId = tenantId;
            UserId = userId;
            IsReaded = false;
        }

        public void SetAsReaded(bool isReaded)
        {
            IsReaded = isReaded;
        }
    }
}
