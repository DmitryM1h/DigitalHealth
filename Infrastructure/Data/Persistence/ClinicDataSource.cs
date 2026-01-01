using DigitalHealth.Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Infrastructure.Data.Persistence
{
    public class ClinicDataSource(TelemetryContext _telemetryContext) : IClinicRepository
    {
        public async Task<Clinic?> GetClinicAsync(Guid clinicId)
        {
            return await _telemetryContext.Clinics.Where(t => t.Id == clinicId).Include(t => t.Doctors).FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        { 
            await _telemetryContext.SaveChangesAsync();
        }


    }
}
