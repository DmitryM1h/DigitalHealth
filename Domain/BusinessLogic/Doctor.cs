using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Entities;

public partial class Doctor : IDoctorLogic
{
    private IScheduleService _scheduleService;
    public Doctor(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    public async Task<IEnumerable<Slot>> GetFreeSlotsAsync(Period period)
    {

        var doctorsSchedule = await _scheduleService.GetUserScheduleAsync(Id, period);

        return doctorsSchedule.Slots.Where(t => t.IsFree());
    }


}
