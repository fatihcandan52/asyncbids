using AutoMapper;
using SigortamNet.Application.Contracts.Operations.Bid;
using SigortamNet.Data.Entities;

namespace SigortamNet.Application.Operations.Bid
{
    public class BidMapper : Profile
    {
        public BidMapper()
        {
            CreateMap<BidInput, BidEntity>();
            CreateMap<BidEntity, BidOutput>()
                .ForMember(x => x.LicensePlate, y => y.MapFrom(z => z.Visitor.LicensePlate));
        }
    }
}
