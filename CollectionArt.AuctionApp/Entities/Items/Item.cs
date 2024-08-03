using Volo.Abp.Domain.Entities;


namespace CollectionArt.AuctionApp.Entities.Items
{
    public class Item : AggregateRoot<Guid>
    {
        public Guid OwnerId { get; set; }
        public Guid FirstOwnerId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }


    }
}
