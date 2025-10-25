
using Domain.Entities.SupportEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfiguration
{
    internal class DoctorInfoConfiguration : IEntityTypeConfiguration<DoctorInfo>
    {
        public void Configure(EntityTypeBuilder<DoctorInfo> builder)
        {

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.HasOne(t => t.Doctor)
                .WithOne(t => t.DoctorInfo)
                .HasForeignKey<DoctorInfo>(t => t.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
