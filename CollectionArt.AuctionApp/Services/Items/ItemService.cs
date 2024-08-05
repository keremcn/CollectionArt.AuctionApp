using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using CollectionArt.AuctionApp.Entities.Items;
using CollectionArt.AuctionApp.Services.Items.Dtos;
using Volo.Abp.Domain.Repositories;
using CollectionArt.AuctionApp.Localization;
using CollectionArt.AuctionApp.Permissions;

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
            GetPolicyName = AuctionAppPermissions.Items.Default;
            GetListPolicyName = AuctionAppPermissions.Items.Default;
            CreatePolicyName = AuctionAppPermissions.Items.Create;
            UpdatePolicyName = AuctionAppPermissions.Items.Edit;
            DeletePolicyName = AuctionAppPermissions.Items.Delete;
        }
    }
}
