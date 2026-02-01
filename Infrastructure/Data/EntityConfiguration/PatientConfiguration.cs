using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Infrastructure.Data.EntityConfiguration;
internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {

        builder
            .HasKey(t => t.Id);

        builder
            .Property(t => t.Id)
            .ValueGeneratedNever();

        //builder
        //    .HasOne(t => t.MedicalCard)
        //    .WithOne()
        //    .HasForeignKey<Patient>()
        //    .OnDelete(DeleteBehavior.Cascade);

    }
}

