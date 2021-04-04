namespace SigortamNet.Data.Entities
{
    public class BidEntity : BaseEntity
    {
        public int VisitorId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public VisitorEntity Visitor { get; set; }
    }
}
