namespace CollectionArt.AuctionApp.Permissions
{
    public static class AuctionAppPermissions
    {
        public const string GroupName = "AuctionApp";
        public static class Items
        {
            public const string Default = GroupName + ".Items";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";

        }
        public static class Auctions
        {
            public const string Default = GroupName + ".Auctions";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";

        }
    }
}
