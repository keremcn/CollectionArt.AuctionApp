using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using CollectionArt.AuctionApp.Entities.Items;
using CollectionArt.AuctionApp.Services.Items.Dtos;
using Volo.Abp.Domain.Repositories;
using CollectionArt.AuctionApp.Localization;

namespace CollectionArt.AuctionApp.Services.Items
{
    public class ItemService : CrudAppService<Item,
        ItemDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateItemDto>, IItemService
    {
        public ItemService(IRepository<Item, Guid> repository):base(repository) 
        {
            LocalizationResource = typeof(AuctionAppResource);
        }
    }
}
