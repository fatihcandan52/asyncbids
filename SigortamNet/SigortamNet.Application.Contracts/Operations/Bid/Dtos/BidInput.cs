namespace SigortamNet.Application.Contracts.Operations.Bid
{
    public class BidInput
    {
        public int VisitorId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
