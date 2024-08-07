using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using CollectionArt.AuctionApp.Services.Auctions.Dtos;
using CollectionArt.AuctionApp.Services.Auctions;



namespace CollectionArt.AuctionApp.Pages.Auctions
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateAuctionDto Auction { get; set; }

        private readonly IAuctionService _auctionService;

        public CreateModalModel(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        public void OnGet(Guid? id)
        {
            Auction = new CreateUpdateAuctionDto() { ItemId = id??new Guid()};

        }
        public async Task<IActionResult> OnPostAsync()
        {
            Auction.HighestOffer = Auction.StartPrice;
            await _auctionService.CreateAsync(Auction);
            return NoContent();
        }
    }
}
