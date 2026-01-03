using Domain.Entities;
using Domain.Repository;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Infrastructure.Data.Persistence
{
    public class PatientRepository(TelemetryContext _dbContext) : IPatientRepository
    {
        public async Task AddPatientAsync(Patient patient)
        {
            await _dbContext.AddAsync(patient);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
