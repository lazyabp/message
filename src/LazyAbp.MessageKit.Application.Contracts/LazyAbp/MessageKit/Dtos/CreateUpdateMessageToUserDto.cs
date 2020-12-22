using System;
using System.ComponentModel;
namespace LazyAbp.MessageKit.Dtos
{
    [Serializable]
    public class CreateUpdateMessageToUserDto
    {
        public Guid? TenantId { get; set; }

        public Guid? UserId { get; set; }
    }
}