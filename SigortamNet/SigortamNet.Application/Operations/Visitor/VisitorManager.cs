using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SigortamNet.Application.Contracts.Operations.Visitor;
using SigortamNet.Contracts.Enums;
using SigortamNet.Contracts.Results;
using SigortamNet.Data.Entities;
using SigortamNet.Data.Repositories;
using SigortamNet.Data.UnitOfWork;
using System;
using System.Collections.Generic;
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

        public async Task<ServiceResult<VisitorOutput>> AddAsync(VisitorInput input)
        {
            try
            {
                var entity = _mapper.Map<VisitorEntity>(input);
                await _visitorRepository.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                return new ServiceResult<VisitorOutput>(Status.Success)
                {
                    Message = "Ziyaretci bilgileri eklendi",
                    Object = _mapper.Map<VisitorOutput>(entity)
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<VisitorOutput>(Status.Error)
                {
                    Message = "Ziyaretci eklenirken bir hata oluştu"
                };
            }
        }

        public async Task<ServiceResult<VisitorOutput>> CheckGetAndInsertAsync(VisitorInput input)
        {
            var checkResult = await GetInfoByIdentificationAndPlate(input);

            if (checkResult.IsSucceed)
            {
                return checkResult;
            }

            var addResult = await AddAsync(input);

            if (addResult.IsSucceed)
            {
                return addResult;
            }

            return new ServiceResult<VisitorOutput>(Status.Error)
            {
                Message = "Ziyaretci kontrolü ve eklenmesi sırasında bir hata oluştu."
            };
        }

        public async Task<ServiceResult<List<VisitorOutput>>> GetListAsync()
        {
            var list = await _visitorRepository.GetAll().ToListAsync();

            return new ServiceResult<List<VisitorOutput>>(Status.Success)
            {
                Object = _mapper.Map<List<VisitorOutput>>(list)
            };
        }

        public async Task<ServiceResult<VisitorOutput>> GetInfoByIdentificationAndPlate(VisitorInput input)
        {
            var entity = await _visitorRepository.FirstOrDefaultAsync(x => x.IdentificationNumber == input.IdentificationNumber && x.LicensePlate == input.LicensePlate);

            if (entity == null)
            {
                return new ServiceResult<VisitorOutput>(Status.Error)
                {
                    Message = "İlgili kayıt bulunamadı"
                };
            }

            return new ServiceResult<VisitorOutput>(Status.Success)
            {
                Object = _mapper.Map<VisitorOutput>(entity)
            };
        }
    }
}
