using Lazy.Abp.MessageKit.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.MessageKit.Admin.Permissions
{
    public class MessageKitAdminPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MessageKitAdminPermissions.GroupName, L("Permission:MessageKitAdmin"));

            var messagePermission = myGroup.AddPermission(MessageKitAdminPermissions.Message.Default, L("Permission:Message"));
            messagePermission.AddChild(MessageKitAdminPermissions.Message.Create, L("Permission:Create"));
            messagePermission.AddChild(MessageKitAdminPermissions.Message.Update, L("Permission:Update"));
            messagePermission.AddChild(MessageKitAdminPermissions.Message.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MessageKitResource>(name);
        }
    }
}
