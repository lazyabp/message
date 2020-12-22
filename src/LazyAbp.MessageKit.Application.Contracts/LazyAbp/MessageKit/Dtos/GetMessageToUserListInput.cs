using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.MessageKit.Dtos
{
    public class GetMessageToUserListInput : PagedAndSortedResultRequestDto
    {
        public bool? IsReaded { get; set; }

        public string Filter { get; set; }

        public bool IncludeDetails { get; set; }
    }
}
