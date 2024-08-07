using CollectionArt.AuctionApp.Entities.Auctions;
using CollectionArt.AuctionApp.Entities.Items;
using CollectionArt.AuctionApp.Services.Auctions;
using CollectionArt.AuctionApp.Services.Auctions.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CollectionArt.AuctionApp.Pages.Auctions
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateAuctionDto Auction { get; set; }

        private readonly IAuctionService _auctionService;

        public EditModalModel(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        public async Task OnGetAsync()
        {

            Auction = ObjectMapper.Map<AuctionDto,CreateUpdateAuctionDto>(await _auctionService.GetAsync(Id));

        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _auctionService.UpdateAsync(Id, Auction);

            return NoContent();
        }
    }
}
