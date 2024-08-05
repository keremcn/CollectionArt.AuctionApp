using CollectionArt.AuctionApp.Localization;
using CollectionArt.AuctionApp.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace CollectionArt.AuctionApp.Menus;


public class AuctionAppMenuContributor : IMenuContributor
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
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<AuctionAppResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AuctionAppMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem("AuctionMenu", l["Menu:Auction"], "/Auctions", icon: "fa fa-book",
            order: 1)
            .RequirePermissions(AuctionAppPermissions.Auctions.Default)

            );
        context.Menu.AddItem(
               new ApplicationMenuItem("ItemMenu", l["Menu:Item"], "/Items", icon: "fa fa-book",
               order: 2).RequirePermissions(AuctionAppPermissions.Items.Default)

               );
        

        if (AuctionAppModule.IsMultiTenant)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        return Task.CompletedTask;
    }
}
