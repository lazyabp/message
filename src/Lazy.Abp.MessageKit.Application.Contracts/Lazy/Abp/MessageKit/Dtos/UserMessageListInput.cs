using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.MessageKit.Dtos
{
    public class UserMessageListInput : PagedAndSortedResultRequestDto
    {
        public bool? IsReaded { get; set; }

        public string Filter { get; set; }
    }
}
