using CollectionArt.AuctionApp.Services.Items;
using CollectionArt.AuctionApp.Services.Items.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CollectionArt.AuctionApp.Pages.Items
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateItemDto Item { get; set; }

        private readonly IItemService _itemService;

        public EditModalModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task OnGetAsync()
        {
            var itemDto = await _itemService.GetAsync(Id);
            Item = ObjectMapper.Map<ItemDto, CreateUpdateItemDto>(itemDto);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _itemService.UpdateAsync(Id, Item);

            return NoContent();
        }



    }
}
