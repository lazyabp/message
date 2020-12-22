using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.MessageKit.Dtos
{
    public class GetMessageListInput : PagedAndSortedResultRequestDto
    {
        public DateTime? CreatedAfter { get; set; }

        public DateTime? CreatedBefore { get; set; }

        public string TypeName { get; set; }

        public string Filter { get; set; }

        public bool IncludeDetails { get; set; }
    }
}
