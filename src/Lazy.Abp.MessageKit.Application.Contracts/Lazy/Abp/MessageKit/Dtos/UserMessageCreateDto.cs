using System;
using System.ComponentModel;
namespace Lazy.Abp.MessageKit.Dtos
{
    [Serializable]
    public class UserMessageCreateDto
    {
        public Guid? TenantId { get; set; }

        public Guid? UserId { get; set; }
    }
}