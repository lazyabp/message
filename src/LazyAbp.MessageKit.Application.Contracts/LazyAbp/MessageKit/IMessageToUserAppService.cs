using System;
using System.Threading.Tasks;
using LazyAbp.MessageKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace LazyAbp.MessageKit
{
    public interface IMessageToUserAppService : IApplicationService, ITransientDependency
    {
        Task<MessageToUserDto> GetAsync(Guid id);

        Task<PagedResultDto<MessageToUserDto>> GetListAsync(GetMessageToUserListInput input);

        Task SetAsReadedAsync(Guid id, SetAsReadedRequestDto input);

        Task DeleteAsync(Guid id);
    }
}