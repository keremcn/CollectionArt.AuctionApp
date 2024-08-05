using AutoMapper;
using CollectionArt.AuctionApp.Services.Items.Dtos;

namespace CollectionArt.AuctionApp.ObjectMapping
{
    public class ItemMapperProfile:Profile
    {
        public ItemMapperProfile()
        {
            CreateMap<ItemDto, CreateUpdateItemDto>().ReverseMap();
        }
    }
}
