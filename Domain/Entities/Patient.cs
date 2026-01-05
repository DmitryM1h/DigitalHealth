using Core.Contracts;
using DigitalHealth.Domain.DomainExceptions;
using DigitalHealth.Domain.Extensions;
using Domain.ValueObjects;



namespace Domain.Entities;

public partial class Patient : IEntity<Guid>
{
  
    public Guid Id { get; init; }
    public string FullName { get; init; }

    private List<Appointment> _appointments = new List<Appointment>();

    public IReadOnlyCollection<Appointment> Appointments => _appointments.AsReadOnly();


    //Убрать id
    public Guid? MedicalRecordId { get; set; }
    public MedicalRecord? MedicalRecord { get; set; }


    public Appointment MakeAppointment(Doctor doctor, Period period)
    {
        var appointmentsForMonth = _appointments.Where(t => t.EventPeriod.StartDate.Month == period.StartDate.Month).Select(t => t.EventPeriod).ToList();

        if (appointmentsForMonth.OverlapsWith(period))
            throw new DomainException("The slot is not available");

        Appointment appointment = Appointment.Create(doctor, this, period);

        _appointments.Add(appointment);

        return appointment;
    }

    public static Patient Create(Guid Id, string FullName)
    {
        return new Patient
        {
            Id = Id,
            FullName = FullName,
        };
    }

    private Patient()
    {
    }

}

