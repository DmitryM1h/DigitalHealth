using Domain.Entities;
using Domain.ValueObjects;


namespace Domain.Repository
{
    public interface ICalendarBlockDataSource
    {

        public Task<List<CalendarBlock>> GetDoctorsCalendarBlocks(Guid doctorId);

        public Task<List<CalendarBlock>> GetDoctorsCalendarBlocksForPeriodAsync(Guid doctorId, Period period);


    }
}
