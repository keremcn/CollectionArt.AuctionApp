using CollectionArt.AuctionApp.Services.Auctions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CollectionArt.AuctionApp.Services.Auctions
{
    public interface IAuctionService : ICrudAppService<
        AuctionDto,
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateAuctionDto>
    {
    }
}
