using Volo.Abp.Domain.Entities;

namespace CollectionArt.AuctionApp.Entities.Galleries
{
    public class Gallery :AggregateRoot<Guid>
    {
        public Guid ItemId { get; set; }
        public string Path { get; set; } = null!;
        public int Order { get; set; }

    }
}
