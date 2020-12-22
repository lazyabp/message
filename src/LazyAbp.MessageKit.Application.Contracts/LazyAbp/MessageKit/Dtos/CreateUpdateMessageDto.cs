using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace LazyAbp.MessageKit.Dtos
{
    [Serializable]
    public class CreateUpdateMessageDto
    {
        public string TypeName { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public List<CreateUpdateMessageToUserDto> MessageToUsers { get; set; }
    }
}