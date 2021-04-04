using Microsoft.EntityFrameworkCore;
using SigortamNet.Contracts.Enums;
using SigortamNet.Data.Configurations;
using SigortamNet.Data.Entities;

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

        public static ModelBuilder AddSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartnerEntity>().HasData(
                    new PartnerEntity
                    {
                        Id = 1,
                        Name = "A Sigorta",
                        ApiUrl = "https://localhost:44300/api/v1/bids",
                        InsuranceType = InsuranceType.AInsurance
                    },
                     new PartnerEntity
                     {
                         Id = 2,
                         Name = "B Sigorta",
                         ApiUrl = "https://localhost:44301/api/v1/bids",
                         InsuranceType = InsuranceType.BInsurance
                     },
                      new PartnerEntity
                      {
                          Id = 3,
                          Name = "C Sigorta",
                          ApiUrl = "https://localhost:44302/api/v1/bids",
                          InsuranceType = InsuranceType.CInsurance
                      }
                );

            return modelBuilder;
        }
    }
}
