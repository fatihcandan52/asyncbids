using SigortamNet.Contracts.Enums;
using SigortamNet.Contracts.Results;

namespace SigortamNet.Integration.CInsurance
{
    public class CInsuranceManager
    {
        public ServiceResult GetBid()
        {
            return new ServiceResult(Status.Success);
        }
    }
}
