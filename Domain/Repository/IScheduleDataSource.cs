using Domain.Entities;

namespace Domain.Repository;

public interface IScheduleDataSource
{
    public Task<WorkSchedule?> GetDoctorsWorkingSchedule(Guid doctorId);

}
