using Domain.Entities;
using Domain.Entities.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Infrastructure.Data.EntityConfiguration;
internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(t => t.Id);

        //builder.Property(t => t.Id).UseIdentityColumn();

        builder.HasMany(t => t.Patients).WithMany(t => t.doctors);

        builder.HasOne(t => t.User)
            .WithOne()
            .HasForeignKey<Doctor>(t => t.Id)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(t => t.WorkSchedule)
            .WithOne(t => t.Doctor)
            .HasForeignKey<WorkSchedule>(t => t.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

