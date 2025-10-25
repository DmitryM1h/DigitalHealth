using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Infrastructure.Data.EntityConfiguration;
internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id).UseIdentityColumn();

        builder.HasMany(t => t.Patients).WithMany(t => t.doctors);
    }
}

