using AutoMapper;
using CollectionArt.AuctionApp.Entities.Auctions;
using CollectionArt.AuctionApp.Services.Auctions.Dtos;

namespace CollectionArt.AuctionApp.Services.Auctions
{
    public class AuctionMapperProfile : Profile
    {
        public AuctionMapperProfile()
        {
            CreateMap<Auction, AuctionDto>();
            CreateMap<CreateUpdateAuctionDto, Auction>();
        }
    }
}
