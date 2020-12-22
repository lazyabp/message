﻿using LazyAbp.MessageKit.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace LazyAbp.MessageKit.Admin
{
    [RemoteService(Name = MessageKitAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("messagekitadmin")]
    [ControllerName("Message")]
    [Route("api/messagekit/messages/admin")]
    public class MessageManagementController : AbpController, IMessageManagementAppService
    {
        private readonly IMessageManagementAppService _service;

        public MessageManagementController(IMessageManagementAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<MessageDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<MessageDto>> GetListAsync(GetMessageListInput input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<MessageDto> CreateAsync(CreateUpdateMessageDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<MessageDto> UpdateAsync(Guid id, CreateUpdateMessageDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
