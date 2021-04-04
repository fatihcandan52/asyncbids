using SigortamNet.Contracts.Enums;
using SigortamNet.Contracts.Results;

namespace SigortamNet.Integration.AInsurance
{
    public class AInsuranceManager
    {
        public ServiceResult GetBid()
        {
            return new ServiceResult(Status.Success);
        }
    }
}
