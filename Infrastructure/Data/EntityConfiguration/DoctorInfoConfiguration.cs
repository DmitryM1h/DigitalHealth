
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfiguration
{
    internal class DoctorInfoConfiguration : IEntityTypeConfiguration<DoctorInfo>
    {
        public void Configure(EntityTypeBuilder<DoctorInfo> builder)
        {

            builder.HasKey(t => t.Id);
            

        }
    }
}
