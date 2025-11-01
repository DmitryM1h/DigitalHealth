
using Domain.Interfaces;
using Domain.Repository;
using Domain.ValueObjects;

namespace Domain.Entities;
public partial class Patient : IPatientLogic
{

    public async Task MakeAppointment(Guid doctorId, Slot slot, IAppointmentDataSource _appointmentDataSource)
    {

        await _appointmentDataSource.CreateAppointmentAsync(Id, doctorId, slot.Period);
    }

}

