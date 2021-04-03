using AutoMapper;
using SigortamNet.Application.Contracts.Operations.Visitor;
using SigortamNet.Data.Entities;

namespace SigortamNet.Application.Operations.Visitor
{
    public class VisitorMapper : Profile
    {
        public VisitorMapper()
        {
            CreateMap<VisitorInput, VisitorEntity>();
            CreateMap<VisitorEntity, VisitorOutput>();
        }
    }
}
