using SigortamNet.Contracts.Enums;
using SigortamNet.Contracts.Results;
using System.Threading.Tasks;

namespace SigortamNet.Integration.Contracts.Insurance
{
    public interface IInsuranceFactoryService
    {
        Task<ServiceResult<InsuranceBidOutput>> GetInsuranceBids(InsuranceType type);
    }
}
