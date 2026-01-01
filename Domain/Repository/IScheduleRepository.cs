using Domain.Entities;

namespace Domain.Repository;

public interface IScheduleRepository
{
    public Task<WorkSchedule?> GetDoctorsWorkingSchedule(Guid doctorId);

}
