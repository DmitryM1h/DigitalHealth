using Domain.Entities;
using Domain.Entities.SupportEntities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data;
public class TelemetryContext : DbContext
{
    public DbSet<Doctor> _doctors { get; set; }
    public DbSet<DoctorInfo> _doctorInfos { get; set; }
    public DbSet<Patient> _patients { get; set; }
    public DbSet<Clinic> _clinics { get; set; }
    public DbSet<Appointment> _appointments { get; set; }

}
