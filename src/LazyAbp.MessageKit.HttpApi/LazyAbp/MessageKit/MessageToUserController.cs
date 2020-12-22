using LazyAbp.MessageKit.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.MessageKit
{
    [RemoteService(Name = MessageKitRemoteServiceConsts.RemoteServiceName)]
    [Area("messagekit")]
    [ControllerName("MessageToUser")]
    [Route("api/messagekit/message-to-users")]
    public class MessageToUserController : MessageKitController, IMessageToUserAppService
    {
        private readonly IMessageToUserAppService _messageToUserAppService;

        public MessageToUserController(IMessageToUserAppService messageToUserAppService)
        {
            _messageToUserAppService = messageToUserAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<MessageToUserDto> GetAsync(Guid id)
        {
            return _messageToUserAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<MessageToUserDto>> GetListAsync(GetMessageToUserListInput input)
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
