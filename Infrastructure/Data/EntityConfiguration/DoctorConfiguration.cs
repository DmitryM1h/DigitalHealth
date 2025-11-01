using Domain.Entities;
using Domain.Entities.DomainEntities;
using Domain.Entities.SupportEntities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Infrastructure.Data.EntityConfiguration;
internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(t => t.Id);


        builder.HasMany(t => t.Patients).WithMany(t => t.doctors);


        builder.HasOne(t => t.WorkSchedule)
            .WithOne()
            .HasForeignKey<Doctor>(t => t.WorkScheduleId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
            ;

       builder.HasOne(t => t.Clinic).WithMany()
            .HasForeignKey(t => t.ClinicId)
            .IsRequired();

        builder.HasOne(t => t.DoctorInfo).WithOne().HasForeignKey<Doctor>(t => t.DoctorInfoId).OnDelete(DeleteBehavior.Cascade);


    }

    public static IEnumerable<Doctor> SeedDoctors()
    {
        var specialties = new[]
        {
        "Cardiology", "Dermatology", "Neurology", "Pediatrics", "Oncology",
        "Orthopedics", "Psychiatry", "Surgery", "Radiology", "Ophthalmology"
    };

        var doctors = new List<Doctor>();
        var random = new Random();

        // Получаем клиники как массив
        List<Clinic> clinics = [ Clinic.Create(Guid.Parse("14444444-4444-4444-4444-444444444444"),"New York", "123 Main Street"),
        Clinic.Create(Guid.Parse("24444444-4444-4444-4444-444444444444"),"Los Angeles", "456 Oak Avenue"),
        Clinic.Create(Guid.Parse("34444444-4444-4444-4444-444444444444"),"Chicago", "789 Pine Street"),
        Clinic.Create(Guid.Parse("44444444-4444-4444-4444-444444444444"), "Houston", "321 Elm Street"),
        Clinic.Create(Guid.Parse("54444444-4444-4444-4444-444444444444"), "Miami", "654 Beach Boulevard")];

        // Создаем WorkSchedules как массив для переиспользования
        var workSchedules = new WorkSchedule[20];
        var baseDate = DateTime.Today;

        // Сначала создаем все WorkSchedules
        for (int i = 0; i < 20; i++)
        {
            workSchedules[i] = new WorkSchedule
            {
                Id = Guid.NewGuid(),
                Monday = Period.Create(
                    new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 8, 0, 0),
                    new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 16, 0, 0)),
                Tuesday = Period.Create(
                    new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 8, 0, 0),
                    new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 16, 0, 0)),
                Wednesday = Period.Create(
                    new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 8, 0, 0),
                    new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 16, 0, 0)),
                Thursday = Period.Create(
                    new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 8, 0, 0),
                    new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 16, 0, 0)),
                Friday = Period.Create(
                    new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 8, 0, 0),
                    new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 15, 0, 0)),
                Saturday = random.Next(0, 2) == 0 ? Period.Create(
                    new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 9, 0, 0),
                    new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 13, 0, 0)) : null,
                Sunday = null
            };
        }

        Random rnd = new();

        // Затем создаем докторов
        for (int i = 0; i < 20; i++)
        {
            var doctorId = Guid.NewGuid();

            var clinicIndex = rnd.Next(1, 4); // Циклически используем клиники
            var currentClinic = clinics[clinicIndex];
            var currClinicId = currentClinic.Id;

            //var doctorInfo = new DoctorInfo
            //{
            //    Id = Guid.NewGuid(),
            //    ShortBio = GenerateShortBio(specialties[random.Next(specialties.Length)]),
            //    Education = GenerateEducation(random),
            //    Qualifications = GenerateQualifications(random),
            //    Awards = GenerateAwards(random),
            //    Publications = GeneratePublications(random),
            //    PhotoUrl = $"https://example.com/doctors/doctor-{i + 1}.jpg"
            //};

            var doctor = Doctor.Create(currClinicId,
                specialties[random.Next(specialties.Length)],
                random.Next(5, 40)
             );

      

            doctors.Add(doctor);
        }

        return doctors;
    }
    private static string GenerateShortBio(string specialty)
    {
        var bios = new[]
        {
        $"Experienced {specialty} specialist with focus on patient-centered care.",
        $"Board-certified {specialty} physician dedicated to excellence in medical practice.",
        $"Renowned {specialty} expert with extensive clinical experience.",
        $"Compassionate {specialty} doctor committed to improving patient outcomes.",
        $"Skilled {specialty} practitioner with innovative treatment approaches."
    };

        var random = new Random();
        return bios[random.Next(bios.Length)];
    }

    private static string GenerateEducation(Random random)
    {
        var universities = new[]
        {
        "Harvard Medical School",
        "Johns Hopkins University School of Medicine",
        "Stanford University School of Medicine",
        "Mayo Clinic Alix School of Medicine",
        "University of California, San Francisco School of Medicine",
        "University of Pennsylvania Perelman School of Medicine"
    };

        var degrees = new[]
        {
        "MD",
        "MD, PhD",
        "DO",
        "MBBS"
    };

        return $"{degrees[random.Next(degrees.Length)]} - {universities[random.Next(universities.Length)]}";
    }

    private static string GenerateQualifications(Random random)
    {
        var qualifications = new[]
        {
        "Board Certified, Fellowship Trained",
        "Diplomate of the American Board, Advanced Cardiac Life Support",
        "Medical License, Specialty Certification",
        "Basic Life Support, Advanced Trauma Life Support",
        "Pediatric Advanced Life Support, Neonatal Resuscitation Program"
    };

        return qualifications[random.Next(qualifications.Length)];
    }

    private static string GenerateAwards(Random random)
    {
        var awards = new[]
        {
        "Physician of the Year 2022, Excellence in Patient Care Award",
        "Top Doctor Award, Medical Innovation Prize",
        "Outstanding Service Award, Clinical Excellence Recognition",
        "Research Achievement Award, Community Service Honor",
        "Teaching Excellence Award, Patient Choice Award",
        null 
    };

        return awards[random.Next(awards.Length)];
    }

    private static string GeneratePublications(Random random)
    {
        var publications = new[]
        {
        "Advanced Techniques in Modern Medicine, Journal of Medical Science 2023",
        "Innovative Approaches to Patient Care, Medical Research Review 2022",
        "Clinical Studies in Specialized Treatment, Healthcare Journal 2021",
        "Recent Advances in Medical Practice, Clinical Medicine Today 2020",
        null 
    };

        return publications[random.Next(publications.Length)];
    }

}

