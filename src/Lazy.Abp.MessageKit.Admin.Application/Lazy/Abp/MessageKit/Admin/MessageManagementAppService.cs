using Lazy.Abp.MessageKit.Admin.Permissions;
using Lazy.Abp.MessageKit.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.MessageKit.Admin
{
    public class MessageManagementAppService :
        CrudAppService<Message, MessageDto, Guid, MessageListRequestDto, MessageCreateUpdateDto, MessageCreateUpdateDto>,
        IMessageManagementAppService
    {
        protected override string GetPolicyName { get; set; } = MessageKitAdminPermissions.Message.Default;
        protected override string GetListPolicyName { get; set; } = MessageKitAdminPermissions.Message.Default;
        protected override string CreatePolicyName { get; set; } = MessageKitAdminPermissions.Message.Create;
        protected override string UpdatePolicyName { get; set; } = MessageKitAdminPermissions.Message.Update;
        protected override string DeletePolicyName { get; set; } = MessageKitAdminPermissions.Message.Delete;

        private readonly IMessageRepository _repository;
        private readonly IUserMessageRepository _userMessageRepository;

        public MessageManagementAppService(
            IMessageRepository repository,
            IUserMessageRepository userMessageRepository
        ) : base(repository)
        {
            _repository = repository;
            _userMessageRepository = userMessageRepository;
        }

        [Authorize(MessageKitAdminPermissions.Message.Default)]
        public override async Task<PagedResultDto<MessageDto>> GetListAsync(MessageListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(input.CreatedAfter, input.CreatedBefore, input.TypeName, input.Filter);

            var messages = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount,
                input.CreatedAfter, input.CreatedBefore, input.TypeName, input.Filter);

            return new PagedResultDto<MessageDto>(
                totalCount,
                ObjectMapper.Map<List<Message>, List<MessageDto>>(messages)
            );
        }

        [Authorize(MessageKitAdminPermissions.Message.Create)]
        public override async Task<MessageDto> CreateAsync(MessageCreateUpdateDto input)
        {
            var message = new Message(GuidGenerator.Create(), input.TypeName, input.Title, input.Body);
            await _repository.InsertAsync(message);

            // 用户消息
            var userMessages = new List<UserMessage>();
            foreach (var user in input.Users)
            {
                userMessages.Add(new UserMessage(GuidGenerator.Create(), message.Id, user.TenantId, user.UserId));
            }

            await _userMessageRepository.InsertManyAsync(userMessages);

            return ObjectMapper.Map<Message, MessageDto>(message);
        }

        [Authorize(MessageKitAdminPermissions.Message.Update)]
        public override async Task<MessageDto> UpdateAsync(Guid id, MessageCreateUpdateDto input)
        {
            var message = await _repository.GetAsync(id);

            message.Update(input.TypeName, input.Title, input.Body);
            await _repository.UpdateAsync(message);

            // 用户消息
            var userMessages = new List<UserMessage>();
            foreach (var user in input.Users)
            {
                userMessages.Add(new UserMessage(GuidGenerator.Create(), message.Id, user.TenantId, user.UserId));
            }

            await _userMessageRepository.InsertManyAsync(userMessages);

            return ObjectMapper.Map<Message, MessageDto>(message);
        }
    }
}
