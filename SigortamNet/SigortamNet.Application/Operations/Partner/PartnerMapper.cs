using AutoMapper;
using SigortamNet.Application.Contracts.Operations.Partner;
using SigortamNet.Data.Entities;

namespace SigortamNet.Application.Operations.Partner
{
    public class PartnerMapper : Profile
    {
        public PartnerMapper()
        {
            CreateMap<PartnerInput, PartnerEntity>();
            CreateMap<PartnerEntity, PartnerOutput>();
        }
    }
}
