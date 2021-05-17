using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Reflection;

namespace Lazy.Abp.MessageKit.Admin.Permissions
{
    public class MessageKitAdminPermissions
    {
        public const string GroupName = "MessageKit.Admin";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(MessageKitAdminPermissions));
        }

        public class Message
        {
            public const string Default = GroupName + ".Message";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
