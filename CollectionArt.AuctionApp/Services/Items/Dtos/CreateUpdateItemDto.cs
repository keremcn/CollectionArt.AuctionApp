using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CollectionArt.AuctionApp.Services.Items.Dtos
{
    public class CreateUpdateItemDto
    {

        [HiddenInput]
        public Guid OwnerId { get; set; }
        [HiddenInput]
        public Guid FirstOwnerId { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }


    }
}
