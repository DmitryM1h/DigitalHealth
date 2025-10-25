using Core.Entities;
using Domain.Entities;
using Domain.Repository;
using Domain.ValueObjects;

namespace Domain.Aggregates
{
    public class Schedule(IAppointmentDataSource _appointmentDataSource ) 
    {

        public Period SchedulePeriod { get; init; }
        public User User { get; init; }
        public IEnumerable<Appointment> Appointments { get; private set; }

        public async Task CreateSchedule()
        {
            Appointments = await _appointmentDataSource.GetAppointmentsForPeriodAsync(User.Id, SchedulePeriod);
        }


    }
}
