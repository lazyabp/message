using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.MessageKit.Dtos
{
    [Serializable]
    public class MessageDto : FullAuditedEntityDto<Guid>
    {
        public string TypeName { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public List<MessageToUserDto> MessageToUsers { get; set; }
    }
}