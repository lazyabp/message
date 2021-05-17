using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace Lazy.Abp.MessageKit.Dtos
{
    [Serializable]
    public class MessageCreateUpdateDto
    {
        public string TypeName { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public List<UserMessageCreateDto> Users { get; set; }
    }
}