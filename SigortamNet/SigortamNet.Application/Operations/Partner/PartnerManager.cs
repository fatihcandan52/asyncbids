using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SigortamNet.Application.Contracts.Operations.Partner;
using SigortamNet.Contracts.Enums;
using SigortamNet.Contracts.Results;
using SigortamNet.Data.Entities;
using SigortamNet.Data.Repositories;
using SigortamNet.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigortamNet.Application.Operations.Partner
{
    public class PartnerManager : IPartnerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PartnerEntity> _partnerRepository;
        private readonly IMapper _mapper;

        public PartnerManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _partnerRepository = unitOfWork.Repository<PartnerEntity>();
        }

        public async Task<ServiceResult> AddAsync(PartnerInput input)
        {
            var entity = _mapper.Map<PartnerEntity>(input);
            await _partnerRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResult(Status.Success)
            {
                Message = "Şirket başarıyla eklendi"
            };
        }

        public async Task<ServiceResult<List<PartnerOutput>>> GetListAsync()
        {
            var list = await _partnerRepository.GetList().ToListAsync();

            return new ServiceResult<List<PartnerOutput>>(Status.Success)
            {
                Object = _mapper.Map<List<PartnerOutput>>(list)
            };
        }
    }
}
