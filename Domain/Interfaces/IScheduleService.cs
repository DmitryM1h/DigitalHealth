using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IScheduleService
{
    public Task<Schedule> GetDoctorFreeGapsForMonthAsync(Guid doctorId, DateTime month);

    public Task<SlotsForDay?> GetDoctorFreeGapsForDayAsync(Guid doctorId, DateTime date);

}
