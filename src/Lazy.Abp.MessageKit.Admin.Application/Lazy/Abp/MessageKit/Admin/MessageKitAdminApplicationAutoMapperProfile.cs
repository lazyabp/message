using AutoMapper;
using Lazy.Abp.MessageKit.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.MessageKit.Admin
{
    public class MessageKitAdminApplicationAutoMapperProfile : Profile
    {
        public MessageKitAdminApplicationAutoMapperProfile()
        {
            CreateMap<Message, MessageDto>();
        }
    }
}
