using System.ComponentModel.DataAnnotations;

namespace CollectionArt.AuctionApp.Services.Items.Dtos
{
    public class CreateUpdateItemDto
    {

        public Guid OwnerId { get; set; }
        public Guid FirstOwnerId { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        
    }
}
