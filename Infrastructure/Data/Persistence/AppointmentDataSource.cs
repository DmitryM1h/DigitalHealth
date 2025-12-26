using Domain.Entities;
using Domain.Repository;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Persistence
{
    public class AppointmentDataSource(TelemetryContext dbContext) : IAppointmentDataSource
    {
        public Task CreateAppointmentAsync(Guid userId, Guid doctorId, Period period)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAppointmentsAsync(Guid userID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Appointment>> GetAppointmentsForPeriodAsync(Guid userID, Period period)
        {

            var temp = await dbContext.Appointments
                .Where(t => t.Doctor.Id == userID).ToListAsync();


            return await dbContext.Appointments
                .Where(t => t.Doctor.Id == userID
                && t.EventPeriod.StartDate >= period.StartDate
                && t.EventPeriod.EndDate <= period.EndDate).ToListAsync();
        }
    }
}
