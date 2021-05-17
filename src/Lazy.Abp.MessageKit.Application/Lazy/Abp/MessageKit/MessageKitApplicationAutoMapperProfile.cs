using Lazy.Abp.MessageKit;
using Lazy.Abp.MessageKit.Dtos;
using AutoMapper;

namespace Lazy.Abp.MessageKit
{
    public class MessageKitApplicationAutoMapperProfile : Profile
    {
        public MessageKitApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Message, MessageDto>();

            CreateMap<UserMessage, UserMessageDto>();
        }
    }
}
