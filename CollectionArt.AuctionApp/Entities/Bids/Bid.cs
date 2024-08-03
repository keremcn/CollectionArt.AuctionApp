using Volo.Abp.Domain.Entities;

namespace CollectionArt.AuctionApp.Entities.Bids
{
    public class Bid : AggregateRoot<Guid>
    {
        public Guid AuctionId { get; set; }
        public Guid UserId { get; set; }
        public decimal BidPrice { get; set; }
        public DateTime BidDate { get; set; }
    }
}
