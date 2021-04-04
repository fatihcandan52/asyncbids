using AutoMapper;
using SigortamNet.Application.Contracts.Operations.Bid;
using SigortamNet.Application.Contracts.Operations.Visitor;
using SigortamNet.MVC.ViewModels;

namespace SigortamNet.MVC.Mapper
{
    public class MvcMapper : Profile
    {
        public MvcMapper()
        {
            CreateMap<VisitorViewModel, VisitorBidInput>();
            CreateMap<VisitorViewModel, VisitorInput>();

            CreateMap<BidOutput, BidInput>().ReverseMap();
        }
    }
}
