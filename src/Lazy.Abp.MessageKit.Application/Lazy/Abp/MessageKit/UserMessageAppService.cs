using System;
using Lazy.Abp.MessageKit.Permissions;
using Lazy.Abp.MessageKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using System.Collections.Generic;
using Volo.Abp.Users;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.MessageKit
{
    [Authorize]
    public class UserMessageAppService : ApplicationService, IUserMessageAppService, ITransientDependency
    {
        private readonly IUserMessageRepository _repository;
        
        public UserMessageAppService(IUserMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserMessageDto> GetAsync(Guid id)
        {
            var message = await _repository.GetByIdAsync(id);
            if (message.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissons"]);

            return ObjectMapper.Map<UserMessage, UserMessageDto>(message);
        }

        public async Task<PagedResultDto<UserMessageDto>> GetListAsync(UserMessageListInput input)
        {
            var totalCount = await _repository.GetCountAsync(CurrentUser.GetId(), input.IsReaded, input.Filter);

            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, 
                input.Sorting, CurrentUser.GetId(), input.IsReaded, input.Filter);

            return new PagedResultDto<UserMessageDto>(
                totalCount,
                ObjectMapper.Map<List<UserMessage>, List<UserMessageDto>>(list)
            );
        }

        public async Task SetAsReadedAsync(Guid id, SetAsReadedRequestDto input)
        {
            var message = await _repository.GetAsync(id);

            if (message.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissons"]);

            if (message != null)
            {
                message.SetAsReaded(input.IsReaded);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var message = await _repository.GetAsync(id);

            if (message.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissons"]);

            await _repository.DeleteAsync(message);
        }
    }
}
