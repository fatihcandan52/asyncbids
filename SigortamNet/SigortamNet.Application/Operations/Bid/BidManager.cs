﻿using AutoMapper;
using SigortamNet.Application.Contracts.Operations.Bid;
using SigortamNet.Contracts.Enums;
using SigortamNet.Contracts.Results;
using SigortamNet.Data.Entities;
using SigortamNet.Data.Repositories;
using SigortamNet.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigortamNet.Application.Operations.Bid
{
    public class BidManager : IBidService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<BidEntity> _bidRepository;
        private readonly IMapper _mapper;

        public BidManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bidRepository = _unitOfWork.Repository<BidEntity>();
        }

        public async Task<ServiceResult> AddAsync(BidInput input)
        {
            var entity = _mapper.Map<BidEntity>(input);
            await _bidRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResult(Status.Success)
            {
                Message = "Teklif bilgisi eklendi"
            };
        }

        public async Task<ServiceResult<List<BidOutput>>> GetListByIdentificationNumberAsync()
        {
            var list = await _bidRepository.GetListAsync();

            return new ServiceResult<List<BidOutput>>(Status.Success)
            {
                Object = _mapper.Map<List<BidOutput>>(list)
            };
        }
    }
}
