using SigortamNet.Contracts.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigortamNet.Application.Contracts.Operations.Visitor
{
    public interface IVisitorService
    {
        Task<ServiceResult<VisitorOutput>> AddAsync(VisitorInput input);
        Task<ServiceResult<List<VisitorOutput>>> GetListAsync();
        Task<ServiceResult<VisitorOutput>> GetInfoByIdentificationAndPlate(VisitorInput input);
        Task<ServiceResult<VisitorOutput>> CheckGetAndInsertAsync(VisitorInput input);
    }
}
