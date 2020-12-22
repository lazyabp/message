using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.MessageKit.Dtos
{
    [Serializable]
    public class MessageToUserDto : FullAuditedEntityDto<Guid>
    {
        public Guid? TenantId { get; set; }

        public Guid? UserId { get; set; }

        public Guid MessageId { get; set; }

        public bool IsReaded { get; set; }

        public MessageViewDto Message { get; set; }
    }
}
