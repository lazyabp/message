using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Lazy.Abp.MessageKit.Web.Menus
{
    public class MessageKitMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(MessageKitMenus.Prefix, displayName: "MessageKit", "~/MessageKit", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}