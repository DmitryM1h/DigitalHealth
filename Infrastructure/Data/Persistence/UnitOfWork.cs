using DigitalHealth.Domain.Repository;
using Domain.Repository;
using Infrastructure.Data;


namespace DigitalHealth.Infrastructure.Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        //public DbSet<Doctor> Doctors => _dbContext.Doctors;
        //public DbSet<Patient> Patients => _dbContext.Patients;

        public UnitOfWork(TelemetryContext _dbContext,
            IDoctorRepository _doctorRepository,
            IPatientRepository _patientRepository,
            IClinicRepository _clinicRepository)
        {
            this._dbContext = _dbContext;
            Doctors = _doctorRepository;
            Patients = _patientRepository;
            Clinics = _clinicRepository;
        }

        public TelemetryContext _dbContext { get; }
        public IDoctorRepository Doctors { get; }
        public IPatientRepository Patients { get; }
        public IClinicRepository Clinics { get; }



        public async Task SaveChangesAsync()
        { 
            await _dbContext.SaveChangesAsync();
        }

        public async Task BeginTransaction()
        {
            await _dbContext.Database.BeginTransactionAsync().
        }
    }
}
