using System.Threading.Tasks;
using LazyAbp.MessageKit.Localization;
using LazyAbp.MessageKit.Permissions;
using Volo.Abp.UI.Navigation;

namespace LazyAbp.MessageKit.Web.Menus
{
    public class MessageKitMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<MessageKitResource>();
            //Add main menu items.

            context.Menu.AddItem(
                new ApplicationMenuItem(MessageKitMenus.Message, l["Menu:Message"], "/MessageKit/Message")
            );

            context.Menu.AddItem(
                new ApplicationMenuItem(MessageKitMenus.MessageToUser, l["Menu:MessageToUser"], "/MessageKit/MessageToUser")
            );

            await Task.Delay(1);
        }
    }
}
