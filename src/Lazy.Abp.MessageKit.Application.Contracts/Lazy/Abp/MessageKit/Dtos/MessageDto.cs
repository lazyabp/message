using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.MessageKit.Dtos
{
    [Serializable]
    public class MessageDto : FullAuditedEntityDto<Guid>
    {
        public string TypeName { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}