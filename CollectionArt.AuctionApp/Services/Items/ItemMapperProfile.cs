using AutoMapper;
using CollectionArt.AuctionApp.Entities.Items;
using CollectionArt.AuctionApp.Services.Items.Dtos;

namespace CollectionArt.AuctionApp.Services.Items
{
    public class ItemMapperProfile:Profile
    {
        public ItemMapperProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<CreateUpdateItemDto, Item>();
        }
    }
}
