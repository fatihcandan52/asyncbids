using SigortamNet.Contracts.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigortamNet.Application.Contracts.Operations.Visitor
{
    public interface IVisitorService
    {
        Task<ServiceResult> AddAsync(VisitorInput input);
        Task<ServiceResult<List<VisitorOutput>>> GetListAsync();
        Task<ServiceResult<VisitorOutput>> GetListByIdentificationAndPlateAsync(VisitorInput input);
    }
}
