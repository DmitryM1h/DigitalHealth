
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.EntityConfiguration
{
    internal class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasMany(t => t.Doctors)
                .WithOne(t => t.Clinic);
        }

        public static IEnumerable<Clinic> SeedClinics()
        {
            return new[]
            {
        Clinic.Create(Guid.Parse("14444444-4444-4444-4444-444444444444"),"New York", "123 Main Street"),
        Clinic.Create(Guid.Parse("24444444-4444-4444-4444-444444444444"),"Los Angeles", "456 Oak Avenue"),
        Clinic.Create(Guid.Parse("34444444-4444-4444-4444-444444444444"),"Chicago", "789 Pine Street"),
        Clinic.Create(Guid.Parse("44444444-4444-4444-4444-444444444444"), "Houston", "321 Elm Street"),
        Clinic.Create(Guid.Parse("54444444-4444-4444-4444-444444444444"), "Miami", "654 Beach Boulevard")
    };
        }
    }
}
