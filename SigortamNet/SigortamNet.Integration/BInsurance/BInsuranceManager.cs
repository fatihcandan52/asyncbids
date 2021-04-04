using SigortamNet.Contracts.Enums;
using SigortamNet.Contracts.Results;

namespace SigortamNet.Integration.BInsurance
{
    public class BInsuranceManager
    {
        public ServiceResult GetBid()
        {
            return new ServiceResult(Status.Success);
        }
    }
}
