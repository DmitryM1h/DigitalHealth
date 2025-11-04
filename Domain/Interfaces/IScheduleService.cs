using Domain.ValueObjects;
using static Domain.Services.ScheduleService;

namespace Domain.Interfaces;

public interface IScheduleService
{
    public Task<Schedule> GetDoctorFreeGapsAsync(Guid doctorId, YearMonth month);
}
