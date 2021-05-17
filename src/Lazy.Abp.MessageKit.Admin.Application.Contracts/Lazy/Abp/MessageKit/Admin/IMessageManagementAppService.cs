using Lazy.Abp.MessageKit.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.MessageKit.Admin
{
    public interface IMessageManagementAppService :
        ICrudAppService<
            MessageDto,
            Guid,
            MessageListRequestDto,
            MessageCreateUpdateDto,
            MessageCreateUpdateDto>
    {
    }
}
