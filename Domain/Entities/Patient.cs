using Core.Contracts;
using DigitalHealth.Abstractions.abstractions;
using DigitalHealth.Domain.DomainExceptions;
using DigitalHealth.Domain.Entities;
using DigitalHealth.Domain.Extensions;



namespace Domain.Entities;

public partial class Patient : AggregateRoot<Guid>, IEntity<Guid>
{
  
    public Guid Id { get; init; }
    public string FullName { get; init; }

    private List<Appointment> _appointments = new List<Appointment>();

    public IReadOnlyCollection<Appointment> Appointments => _appointments.AsReadOnly();

    public MedicalCard MedicalCard { get; set; }


    public Appointment ConfirmAppointment(Appointment appointment)
    {
        var startdate = appointment.EventPeriod.StartDate;

        var appointmentsForMonth = _appointments
            .Where(t => t.EventPeriod.IsSameDate(appointment.EventPeriod))
            .Select(t => t.EventPeriod)
            .ToList();

        if (appointmentsForMonth.OverlapsWith(appointment.EventPeriod))
            throw new DomainException("The slot is not available");

        _appointments.Add(appointment);

        return appointment;
    }

    public static Patient Create(Guid Id, string FullName)
    {
        var medicalCard = new MedicalCard();
        return new Patient
        {
            Id = Id,
            FullName = FullName,
            MedicalCard = medicalCard
        };
    }

    private Patient()
    {
    }

}

