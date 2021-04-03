using SigortamNet.Contracts.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigortamNet.Application.Contracts.Operations.Partner
{
    public interface IPartnerService
    {
        Task<ServiceResult> AddAsync(PartnerInput input);
        Task<ServiceResult<List<PartnerOutput>>> GetListAsync();
    }
}
