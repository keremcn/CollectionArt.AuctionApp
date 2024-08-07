using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static CollectionArt.AuctionApp.Entities.Enumlar;

namespace CollectionArt.AuctionApp.Services.Auctions.Dtos
{
    public class CreateUpdateAuctionDto
    {
        
        public Guid ItemId { get; set; }
        [HiddenInput]
        public Guid? WinnerId { get; set; }

        [Required]
        public AuctionStatus AuctionStatus { get; set; } = AuctionStatus.Active;

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        [Required]
        [DataType(DataType.Currency)]
        public int StartPrice { get; set; }

        [DataType(DataType.Currency)]
        [HiddenInput]
        public int HighestOffer { get; set; } 
    }
}
