using SigortamNet.Contracts.Enums;
using SigortamNet.Contracts.Results;
using SigortamNet.Integration.Contracts.Insurance;
using System.Threading.Tasks;

namespace SigortamNet.Integration.Insurance
{
    public class InsuranceFactoryManager : IInsuranceFactoryService
    {
        public async Task<ServiceResult<InsuranceBidOutput>> GetInsuranceBids(InsuranceType type)
        {
            switch (type)
            {
                case InsuranceType.AInsurance:
                    break;
                case InsuranceType.BInsurance:
                    break;
                case InsuranceType.CInsurance:
                    break;
                default:
                    break;
            }

            return new ServiceResult<InsuranceBidOutput>(Status.Success)
            {
                Object = new InsuranceBidOutput()
            };
        }
    }
}
