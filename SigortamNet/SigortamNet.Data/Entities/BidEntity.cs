namespace SigortamNet.Data.Entities
{
    public class BidEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string LicensePlate { get; set; }
    }
}
