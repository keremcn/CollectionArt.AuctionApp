using CollectionArt.AuctionApp.Services.Items;
using CollectionArt.AuctionApp.Services.Items.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CollectionArt.AuctionApp.Pages.Items
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateItemDto Item { get; set; }

        private readonly IItemService _itemService;

        public CreateModalModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void OnGet()
        {

            Item = new CreateUpdateItemDto() { FirstOwnerId = CurrentUser.Id.Value, OwnerId = CurrentUser.Id.Value };
        }

        public async Task<IActionResult> OnPostAsync()
        {

            await _itemService.CreateAsync(Item);
            return NoContent();
        }
    }
}
