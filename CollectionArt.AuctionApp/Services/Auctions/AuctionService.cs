using CollectionArt.AuctionApp.Entities.Auctions;
using CollectionArt.AuctionApp.Localization;
using CollectionArt.AuctionApp.Services.Auctions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CollectionArt.AuctionApp.Services.Auctions
{
    public class AuctionService : CrudAppService<Auction,
        AuctionDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateAuctionDto>,IAuctionService
    {
        public AuctionService(IRepository<Auction, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(AuctionAppResource);
        }
    }
}
