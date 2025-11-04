using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.EntityConfiguration
{
    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Doctor)
                .WithMany(t => t.Appointments)
                .HasForeignKey(t => t.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Patient)
                .WithMany(t => t.Appointments)
                .HasForeignKey(t => t.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ComplexProperty(t => t.EventPeriod);

        }
    }
}
