namespace LazyAbp.MessageKit
{
    public static class MessageKitDbProperties
    {
        public static string DbTablePrefix { get; set; } = "MessageKit";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "MessageKit";
    }
}
