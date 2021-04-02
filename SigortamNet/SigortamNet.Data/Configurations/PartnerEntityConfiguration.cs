using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigortamNet.Data.Entities;

namespace SigortamNet.Data.Configurations
{
    public class PartnerEntityConfiguration : BaseEntityConfiguration<PartnerEntity>
    {
        public override void Configure(EntityTypeBuilder<PartnerEntity> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.ApiUrl)
                .HasMaxLength(100)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
