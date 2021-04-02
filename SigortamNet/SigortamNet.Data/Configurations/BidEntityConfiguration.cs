using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigortamNet.Data.Entities;

namespace SigortamNet.Data.Configurations
{
    public class BidEntityConfiguration : BaseEntityConfiguration<BidEntity>
    {
        public override void Configure(EntityTypeBuilder<BidEntity> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Logo)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.LicensePlate)
                .HasMaxLength(20)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
