using Domain.Entities;
using Domain.ValueObjects;


namespace Domain.Repository
{
    public interface IAppointmentRepository
    {

        public Task<List<Appointment>> GetAppointmentsAsync(Guid userID);
        public Task<List<Appointment>> GetAppointmentsForPeriodAsync(Guid userID, Period period);
        public Task CreateAppointmentAsync(Guid userId, Guid doctorId, Period period);


    }
}
