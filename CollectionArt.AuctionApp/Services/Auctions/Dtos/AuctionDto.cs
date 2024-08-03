using Volo.Abp.Application.Dtos;
using static CollectionArt.AuctionApp.Entities.Enumlar;

namespace CollectionArt.AuctionApp.Services.Auctions.Dtos;

public class AuctionDto: AuditedEntityDto<Guid>
{
    public Guid ItemId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal StartPrice { get; set; }
    public decimal HighestOffer { get; set; }
    public Guid? WinnerId { get; set; }
    public AuctionStatus AuctionStatus { get; set; }
}
