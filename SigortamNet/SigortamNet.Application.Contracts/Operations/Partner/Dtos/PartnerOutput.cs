using SigortamNet.Contracts.Enums;

namespace SigortamNet.Application.Contracts.Operations.Partner
{
    public class PartnerOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApiUrl { get; set; }
        public InsuranceType InsuranceType { get; set; }
    }
}
