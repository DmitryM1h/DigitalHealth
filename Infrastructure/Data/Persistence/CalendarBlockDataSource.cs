using Domain.Entities.DomainEntities;
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
    public class CalendarBlockDataSource(TelemetryContext dbContext) : ICalendarBlockDataSource
    {
        public Task<List<CalendarBlock>> GetDoctorsCalendarBlocks(Guid doctorId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CalendarBlock>> GetDoctorsCalendarBlocksForPeriodAsync(Guid doctorId, Period period)
        {
            return await dbContext.CalendarBlocks.Where(t => t.DoctorId == doctorId && t.period.StartDate >= period.StartDate
                                                             && t.period.EndDate <= period.EndDate).ToListAsync();
        }
    }
}
