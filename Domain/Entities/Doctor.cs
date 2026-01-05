using Core.Contracts;
using DigitalHealth.Domain.Extensions;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Doctor : AggregateRoot<Guid>, IEntity<Guid>
{

    public Guid Id { get; init; }
    public string FullName { get; init; }

    private List<Appointment> _appointments = new List<Appointment>();

    //private List<Patient> _patients = new List<Patient>();

    private List<CalendarBlock> _calendarBlocks = new List<CalendarBlock>();

    public IReadOnlyCollection<Appointment> Appointments => _appointments.AsReadOnly();
    //public IReadOnlyCollection<Patient> Patients => _patients.AsReadOnly();
    public IReadOnlyCollection<CalendarBlock> CalendarBlocks => _calendarBlocks.AsReadOnly();

    public string Specialty { get; private set; } = null!;
    public int Capacity { get; private set; }


    public Clinic Clinic { get; private set; } = null!;
    public DoctorInfo? DoctorInfo { get; private set; }
    public Guid? DoctorInfoId { get; private set; }


    public void ConfirmAppointment(Appointment appointment)
    {
        var patient = appointment.Patient;
        var period = appointment.EventPeriod;

        var appointmentsForMonth = _appointments.Where(t => t.EventPeriod.StartDate.Month == period.StartDate.Month).Select(t => t.EventPeriod);
        var blocksForMonth = _calendarBlocks.Where(t => t.period.StartDate.Month == period.StartDate.Month).Select(t => t.period);
        var occupiedPeriods = appointmentsForMonth.Concat(blocksForMonth).ToList();

        if (occupiedPeriods.OverlapsWith(period))
            throw new Exception();

        //Appointment appointment = Appointment.Create(this, patient, period);

        _appointments.Add(appointment);
    }


    public static Doctor Create(Guid Id, Clinic clinic,
       string fullName,
       string specialty,
       int capacity)
    {
        return new Doctor
        {
            Id = Id,
            Clinic = clinic,
            FullName = fullName,
            Specialty = specialty,
            Capacity = capacity,
            _appointments = new List<Appointment>(),
            //_patients = new List<Patient>()
        };
    }


    private Doctor() { }

}

