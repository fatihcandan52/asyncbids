using SigortamNet.Contracts.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigortamNet.Application.Contracts.Operations.Bid
{
    public interface IBidService
    {
        Task<ServiceResult> AddAsync(BidInput input);
        Task<ServiceResult<List<BidOutput>>> GetLastBidsByIdentificationAsync(string identificationNumber);
    }
}
