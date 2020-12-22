using LazyAbp.MessageKit;
using LazyAbp.MessageKit.Dtos;
using AutoMapper;

namespace LazyAbp.MessageKit
{
    public class MessageKitApplicationAutoMapperProfile : Profile
    {
        public MessageKitApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Message, MessageDto>();
            CreateMap<Message, MessageViewDto>();
            CreateMap<CreateUpdateMessageDto, Message>(MemberList.Source);

            CreateMap<MessageToUser, MessageToUserDto>();
            CreateMap<MessageToUserDto, CreateUpdateMessageToUserDto>();
            CreateMap<CreateUpdateMessageToUserDto, MessageToUser>(MemberList.Source)
                .ForMember(x => x.TenantId, op => op.Ignore())
                .ForMember(x => x.UserId, op => op.Ignore())
                .ForMember(x => x.IsReaded, op => op.Ignore());
        }
    }
}
