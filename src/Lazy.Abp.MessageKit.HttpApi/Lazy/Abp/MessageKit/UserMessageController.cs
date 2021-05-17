using Lazy.Abp.MessageKit.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.MessageKit
{
    [RemoteService(Name = MessageKitRemoteServiceConsts.RemoteServiceName)]
    [Area("messagekit")]
    [ControllerName("UserMessage")]
    [Route("api/messagekit/user-messages")]
    public class UserMessageController : MessageKitController, IUserMessageAppService
    {
        private readonly IUserMessageAppService _messageToUserAppService;

        public UserMessageController(IUserMessageAppService messageToUserAppService)
        {
            _messageToUserAppService = messageToUserAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<UserMessageDto> GetAsync(Guid id)
        {
            return _messageToUserAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<UserMessageDto>> GetListAsync(UserMessageListInput input)
        {
            return _messageToUserAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}/set-as-read")]
        public Task SetAsReadedAsync(Guid id, SetAsReadedRequestDto input)
        {
            return _messageToUserAppService.SetAsReadedAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _messageToUserAppService.DeleteAsync(id);
        }
    }
}
