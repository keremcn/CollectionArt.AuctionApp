using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace CollectionArt.AuctionApp;

[Dependency(ReplaceServices = true)]
public class AuctionAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AuctionApp";
}
