using CollectionArt.AuctionApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CollectionArt.AuctionApp.Permissions
{
    public class AuctionAppPermissionDefinitionProvider: PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var auctionAppGroup = context.AddGroup(AuctionAppPermissions.GroupName, L("Permission:AuctionApp"));

            var itemsPermission = auctionAppGroup.AddPermission(AuctionAppPermissions.Items.Default, L("Permission:Items"));
            itemsPermission.AddChild(AuctionAppPermissions.Items.Create, L("Permission:Items.Create"));
            itemsPermission.AddChild(AuctionAppPermissions.Items.Edit, L("Permission:Items.Edit"));
            itemsPermission.AddChild(AuctionAppPermissions.Items.Delete, L("Permission:Items.Delete"));

            var auctionPermission = auctionAppGroup.AddPermission(AuctionAppPermissions.Auctions.Default, L("Permission:Auctions"));
            auctionPermission.AddChild(AuctionAppPermissions.Auctions.Create, L("Permission:Auctions.Create"));
            auctionPermission.AddChild(AuctionAppPermissions.Auctions.Edit, L("Permission:Auctions.Edit"));
            auctionPermission.AddChild(AuctionAppPermissions.Auctions.Delete, L("Permission:Auctions.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AuctionAppResource>(name);
        }
    }
}
