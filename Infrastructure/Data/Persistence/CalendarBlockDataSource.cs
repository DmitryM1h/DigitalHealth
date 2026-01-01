using Domain.Entities;
using Domain.Repository;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.Persistence
{
    public class CalendarBlockDataSource(TelemetryContext dbContext) : ICalendarBlockRepository
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
