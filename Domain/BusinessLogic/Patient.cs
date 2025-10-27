
using Domain.Interfaces;
using Domain.Repository;
using Domain.ValueObjects;

namespace Domain.Entities;
public partial class Patient(IAppointmentDataSource _appointmentDataSource) : IPatientLogic
{

    public async Task MakeAppointment(Guid doctorId, Slot slot)
    {

        await _appointmentDataSource.CreateAppointmentAsync(Id, doctorId, slot.Period);
    }

}

