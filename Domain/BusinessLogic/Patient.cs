
using Domain.Interfaces;
using Domain.Repository;

namespace Domain.Entities;
public partial class Patient(IAppointmentDataSource _appointmentDataSource) : IPatientLogic
{

    public async Task MakeAppointment(Guid doctorId, Period period)
    {
        await _appointmentDataSource.CreateAppointmentAsync(Id, doctorId, period);
    }

}

