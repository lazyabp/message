using LazyAbp.MessageKit.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace LazyAbp.MessageKit.Admin
{
    public interface IMessageManagementAppService :
        ICrudAppService<
            MessageDto,
            Guid,
            GetMessageListInput,
            CreateUpdateMessageDto,
            CreateUpdateMessageDto>
    {
    }
}
