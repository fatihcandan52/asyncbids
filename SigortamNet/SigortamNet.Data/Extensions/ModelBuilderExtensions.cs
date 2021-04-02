using Microsoft.EntityFrameworkCore;
using SigortamNet.Data.Configurations;

namespace SigortamNet.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder AddEntityConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PartnerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new VisitorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BidEntityConfiguration());

            return modelBuilder;
        }
    }
}
