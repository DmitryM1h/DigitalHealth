using DigitalHealth.Domain.Repository;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace DigitalHealth.Infrastructure.Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
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

        public async Task BeginTransactionAsync()
        {
            _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
        }
        public async Task CommitTransactionAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task SaveChangesAsync()
        { 
            await _dbContext.SaveChangesAsync();
        }
    }
}
