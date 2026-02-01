using DigitalHealth.Domain.Entities;
using Domain.Entities;
using Infrastructure.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;
public class TelemetryContext : DbContext
{
    public TelemetryContext(DbContextOptions<TelemetryContext> options)
            : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DoctorInfo> DoctorInfos { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<WorkSchedule> WorkSchedules { get; set; }
    public DbSet<CalendarBlock> CalendarBlocks { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<MedicalDevice> MedicalDevices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("Telemetry");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Clinic>(t => t.HasData(ClinicConfiguration.SeedClinics()));
    }


}
