using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.MessageKit
{
    public class Message : FullAuditedAggregateRoot<Guid>
    {
        [MaxLength(MessageConsts.MaxTypeNameLength)]
        public virtual string TypeName { get; protected set; }

        [MaxLength(MessageConsts.MaxTitleLength)]
        public virtual string Title { get; protected set; }

        public virtual string Body { get; protected set; }

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
        }

        public void Update(string typeName, string title, string body)
        {
            TypeName = typeName;
            Title = title;
            Body = body;
        }
    }
}
