using System;
using System.Threading.Tasks;
using Lazy.Abp.MessageKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.MessageKit
{
    public interface IUserMessageAppService : IApplicationService, ITransientDependency
    {
        Task<UserMessageDto> GetAsync(Guid id);

        Task<PagedResultDto<UserMessageDto>> GetListAsync(UserMessageListInput input);

        Task SetAsReadedAsync(Guid id, SetAsReadedRequestDto input);

        Task DeleteAsync(Guid id);
    }
}