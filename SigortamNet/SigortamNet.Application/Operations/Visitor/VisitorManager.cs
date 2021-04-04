using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SigortamNet.Application.Contracts.Operations.Visitor;
using SigortamNet.Contracts.Enums;
using SigortamNet.Contracts.Results;
using SigortamNet.Data.Entities;
using SigortamNet.Data.Repositories;
using SigortamNet.Data.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigortamNet.Application.Operations.Visitor
{
    public class VisitorManager : IVisitorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<VisitorEntity> _visitorRepository;
        private readonly IMapper _mapper;

        public VisitorManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _visitorRepository = _unitOfWork.Repository<VisitorEntity>();
        }

        public async Task<ServiceResult> AddAsync(VisitorInput input)
        {
            var entity = _mapper.Map<VisitorEntity>(input);
            await _visitorRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResult(Status.Success)
            {
                Message = "Ziyaretci bilgileri eklendi"
            };
        }

        public async Task<ServiceResult<List<VisitorOutput>>> GetListAsync()
        {
            var list = await _visitorRepository.GetList().ToListAsync();

            return new ServiceResult<List<VisitorOutput>>(Status.Success)
            {
                Object = _mapper.Map<List<VisitorOutput>>(list)
            };
        }

        public async Task<ServiceResult<VisitorOutput>> GetListByIdentificationAndPlateAsync(VisitorInput input)
        {
            var list = await _visitorRepository.GetList().ToListAsync();

            return new ServiceResult<VisitorOutput>(Status.Success)
            {
                Object = _mapper.Map<VisitorOutput>(list.FirstOrDefault())
            };
        }
    }
}
