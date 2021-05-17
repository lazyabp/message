using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.MessageKit.Dtos
{
    public class MessageListRequestDto : PagedAndSortedResultRequestDto
    {
        public DateTime? CreatedAfter { get; set; }

        public DateTime? CreatedBefore { get; set; }

        public string TypeName { get; set; }

        public string Filter { get; set; }
    }
}
