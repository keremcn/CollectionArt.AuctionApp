using Volo.Abp.Application.Dtos;

namespace CollectionArt.AuctionApp.Services.Items.Dtos
{
    public class ItemDto : AuditedEntityDto<Guid>
    {
        public Guid OwnerId { get; set; }
        public Guid FirstOwnerId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
}
