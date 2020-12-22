using Volo.Abp.Reflection;

namespace LazyAbp.MessageKit.Permissions
{
    public class MessageKitPermissions
    {
        public const string GroupName = "MessageKit";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(MessageKitPermissions));
        }
    }
}
