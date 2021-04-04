using SigortamNet.Contracts.Enums;

namespace SigortamNet.Data.Entities
{
    public class PartnerEntity : BaseEntity
    {
        public InsuranceType InsuranceType { get; set; }
        public string Name { get; set; }
        public string ApiUrl { get; set; }
    }
}
