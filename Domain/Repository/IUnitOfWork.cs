using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Domain.Repository
{
    public interface IUnitOfWork
    {
        public IDoctorRepository Doctors { get; }
        public IPatientRepository Patients { get; }
        public IClinicRepository Clinics { get; }
        public Task BeginTransactionAsync();
        public Task CommitTransactionAsync();
        public Task SaveChangesAsync();
    }
}
