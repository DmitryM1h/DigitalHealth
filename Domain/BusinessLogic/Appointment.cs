using Domain.Interfaces;
using Domain.ValueObjects;


namespace Domain.Entities;

public partial class Appointment : IAppointmentLogic
{

    public Appointment(Period _period)
    {
        EventPeriod = _period;
    }


}
