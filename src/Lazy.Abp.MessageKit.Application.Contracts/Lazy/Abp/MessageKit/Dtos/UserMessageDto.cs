using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.MessageKit.Dtos
{
    [Serializable]
    public class UserMessageDto : AuditedEntityDto<Guid>
    {
        public Guid? TenantId { get; set; }

        public Guid? UserId { get; set; }

        public Guid MessageId { get; set; }

        public bool IsReaded { get; set; }

        public MessageDto Message { get; set; }
    }
}
