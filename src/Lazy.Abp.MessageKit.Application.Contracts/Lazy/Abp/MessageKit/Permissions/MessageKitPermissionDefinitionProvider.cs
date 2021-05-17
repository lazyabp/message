using Lazy.Abp.MessageKit.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.MessageKit.Permissions
{
    public class MessageKitPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MessageKitPermissions.GroupName, L("Permission:MessageKit"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MessageKitResource>(name);
        }
    }
}
