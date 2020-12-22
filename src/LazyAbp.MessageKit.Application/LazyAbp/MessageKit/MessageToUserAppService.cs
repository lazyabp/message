using System;
using LazyAbp.MessageKit.Permissions;
using LazyAbp.MessageKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using System.Collections.Generic;
using Volo.Abp.Users;
using Volo.Abp.DependencyInjection;

namespace LazyAbp.MessageKit
{
    [Authorize]
    public class MessageToUserAppService : ApplicationService, IMessageToUserAppService, ITransientDependency
    {
        private readonly IMessageToUserRepository _repository;
        
        public MessageToUserAppService(IMessageToUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageToUserDto> GetAsync(Guid id)
        {
            var message = await _repository.GetByIdAsync(id);
            if (message.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissons"]);

            return ObjectMapper.Map<MessageToUser, MessageToUserDto>(message);
        }

        public async Task<PagedResultDto<MessageToUserDto>> GetListAsync(GetMessageToUserListInput input)
        {
            var totalCount = await _repository.GetCountAsync(CurrentUser.GetId(), input.IsReaded, input.Filter, input.IncludeDetails);
            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Sorting, CurrentUser.GetId(), 
                input.IsReaded, input.Filter, input.IncludeDetails);

            return new PagedResultDto<MessageToUserDto>(
                    totalCount,
                    ObjectMapper.Map<List<MessageToUser>, List<MessageToUserDto>>(list)
                );
        }

        public async Task SetAsReadedAsync(Guid id, SetAsReadedRequestDto input)
        {
            var message = await _repository.GetAsync(id);
            if (message.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissons"]);

            if (message != null && (message.TenantId == CurrentUser.TenantId || message.UserId == CurrentUser.Id))
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
