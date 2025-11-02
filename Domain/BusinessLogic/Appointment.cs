using Domain.Interfaces;
using Domain.ValueObjects;


namespace Domain.Entities;

public partial class Appointment : IAppointmentLogic
{

    public Appointment(Period _period)
    {
        EventPeriod = _period;
    }

    public static Appointment Create(
        Period eventPeriod,
        Guid doctorId,
        Guid patientId,
        Doctor doctor,
        Patient patient)
    {
        return new Appointment
        {
            Id = Guid.NewGuid(),
            EventPeriod = eventPeriod,
            DoctorId = doctorId,
            PatientId = patientId,
            doctor = doctor,
            patient = patient
        };
    }
}
