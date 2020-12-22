using LazyAbp.MessageKit.Admin.Permissions;
using LazyAbp.MessageKit.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.MessageKit.Admin
{
    public class MessageManagementAppService : CrudAppService<Message, MessageDto, Guid, GetMessageListInput, CreateUpdateMessageDto, CreateUpdateMessageDto>,
        IMessageManagementAppService
    {
        protected override string GetPolicyName { get; set; } = MessageKitAdminPermissions.Message.Default;
        protected override string GetListPolicyName { get; set; } = MessageKitAdminPermissions.Message.Default;
        protected override string CreatePolicyName { get; set; } = MessageKitAdminPermissions.Message.Create;
        protected override string UpdatePolicyName { get; set; } = MessageKitAdminPermissions.Message.Update;
        protected override string DeletePolicyName { get; set; } = MessageKitAdminPermissions.Message.Delete;

        private readonly IMessageRepository _repository;

        public MessageManagementAppService(IMessageRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [Authorize(MessageKitAdminPermissions.Message.Default)]
        public override async Task<MessageDto> GetAsync(Guid id)
        {
            var message = await _repository.GetByIdAsync(id, true);

            return ObjectMapper.Map<Message, MessageDto>(message);
        }

        [Authorize(MessageKitAdminPermissions.Message.Default)]
        public override async Task<PagedResultDto<MessageDto>> GetListAsync(GetMessageListInput input)
        {
            var totalCount = await _repository.GetCountAsync(input.CreatedAfter, input.CreatedBefore, input.TypeName, input.Filter);
            var messages = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.CreatedAfter, input.CreatedBefore, input.TypeName, input.Filter, input.IncludeDetails);

            return new PagedResultDto<MessageDto>(
                    totalCount,
                    ObjectMapper.Map<List<Message>, List<MessageDto>>(messages)
                );
        }

        [Authorize(MessageKitAdminPermissions.Message.Create)]
        public override async Task<MessageDto> CreateAsync(CreateUpdateMessageDto input)
        {
            var message = new Message(GuidGenerator.Create(), input.TypeName, input.Title, input.Body);
            foreach (var messageToUser in input.MessageToUsers)
                message.AddUser(GuidGenerator.Create(), messageToUser.UserId, messageToUser.TenantId);

            message = await _repository.InsertAsync(message);

            return ObjectMapper.Map<Message, MessageDto>(message);
        }

        [Authorize(MessageKitAdminPermissions.Message.Update)]
        public override async Task<MessageDto> UpdateAsync(Guid id, CreateUpdateMessageDto input)
        {
            var message = await _repository.GetByIdAsync(id);
            // 删除移除的用户
            var tenantIds = input.MessageToUsers.Where(q => q.TenantId.HasValue).Select(x => x.TenantId).ToList();
            var userIds = input.MessageToUsers.Where(q => q.UserId.HasValue).Select(x => x.UserId).ToList();

            if (tenantIds.Count > 0)
                message.MessageToUsers.RemoveAll(x => !tenantIds.Contains(x.TenantId));
            else if (userIds.Count > 0)
                message.MessageToUsers.RemoveAll(x => !userIds.Contains(x.UserId));

            foreach (var messageToUser in input.MessageToUsers)
                message.AddUser(GuidGenerator.Create(), messageToUser.UserId, messageToUser.TenantId);

            message.Update(input.TypeName, input.Title, input.Body);

            return ObjectMapper.Map<Message, MessageDto>(message);
        }
    }
}
