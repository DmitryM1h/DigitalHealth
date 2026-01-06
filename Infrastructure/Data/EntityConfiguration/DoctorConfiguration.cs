using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Infrastructure.Data.EntityConfiguration;
internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder
            .HasKey(t => t.Id);

        builder
            .Property(t => t.Id)
            .ValueGeneratedNever();

        //builder
        //    .HasMany(t => t.Patients);

        builder
            .HasMany(t => t.CalendarBlocks)
            .WithOne(t => t.Doctor);
            

        builder
            .HasOne(t => t.DoctorInfo)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(t => t.WorkSchedule)
            .WithOne()
            .HasForeignKey<Doctor>("WorkScheduleId") // EF почему то сам не понимает...
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

    }


}

