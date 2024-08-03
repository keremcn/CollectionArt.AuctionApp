using Volo.Abp.Domain.Entities;

namespace CollectionArt.AuctionApp.Entities.Profiles
{
    public class UserProfile : AggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
        public string? ProfileImage { get; set; }
        public string? Adress { get; set; }
        public string? EMail { get; set; }
        public string? SocialMediaLinks { get; set; }
        public string? Description { get; set; }
    }
}
