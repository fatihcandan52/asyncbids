using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigortamNet.Data.Entities;

namespace SigortamNet.Data.Configurations
{
    public class VisitorEntityConfiguration : BaseEntityConfiguration<VisitorEntity>
    {
        public override void Configure(EntityTypeBuilder<VisitorEntity> builder)
        {
            builder.Property(x=> x.IdentificationNumber)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.LicensePlate)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.LicenseSerialCode)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(x => x.LicenseSerialNo)
               .HasMaxLength(6)
               .IsRequired();

            base.Configure(builder);
        }
    }
}
