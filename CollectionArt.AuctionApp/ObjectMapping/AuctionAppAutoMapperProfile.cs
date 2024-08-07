using AutoMapper;
using CollectionArt.AuctionApp.Entities.Auctions;
using CollectionArt.AuctionApp.Entities.Items;
using CollectionArt.AuctionApp.Services.Auctions.Dtos;
using CollectionArt.AuctionApp.Services.Items.Dtos;

namespace CollectionArt.AuctionApp.ObjectMapping;

public class AuctionAppAutoMapperProfile : Profile
{
    public AuctionAppAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */

        //auctions
        CreateMap<AuctionDto, CreateUpdateAuctionDto>();
        CreateMap<Auction, AuctionDto>();
        CreateMap<CreateUpdateAuctionDto, Auction>();


        //items

        CreateMap<Item, ItemDto>();
        CreateMap<CreateUpdateItemDto, Item>();
        CreateMap<ItemDto, CreateUpdateItemDto>().ReverseMap();
    }
}
