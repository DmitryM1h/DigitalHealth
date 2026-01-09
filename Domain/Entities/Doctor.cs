using Core.Contracts;
using DigitalHealth.Abstractions.abstractions;
using DigitalHealth.Domain.DomainExceptions;
using DigitalHealth.Domain.Extensions;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Doctor : AggregateRoot<Guid>, IEntity<Guid>
{

    public Guid Id { get; init; }
    public string FullName { get; init; }

    private List<Appointment> _appointments = new List<Appointment>();

    private List<CalendarBlock> _calendarBlocks = new List<CalendarBlock>();

    public IReadOnlyCollection<Appointment> Appointments => _appointments.AsReadOnly();
    public IReadOnlyCollection<CalendarBlock> CalendarBlocks => _calendarBlocks.AsReadOnly();

    public string Specialty { get; private set; } = null!;
    public int Capacity { get; private set; }


    public WorkSchedule? WorkSchedule { get; private set; }
    public Clinic Clinic { get; private set; } = null!;
    public DoctorInfo? DoctorInfo { get; private set; }
    public Guid? DoctorInfoId { get; private set; }


    public void ConfirmAppointment(Appointment appointment)
    {
        var period = appointment.EventPeriod;

        if(WorkSchedule is null)
            throw new DomainException("Work schedule is not set. Doctor must configure working hours first.");

        if (!WorkSchedule.IsWorkingHours(period))
            throw new DomainException("Appointment time is outside working hours");

        var appointmentsForMonth = _appointments
            .Where(t => t.EventPeriod.StartDate.Month == period.StartDate.Month
                        && t.EventPeriod.StartDate.Day == period.StartDate.Day
                        && t.EventPeriod.StartDate.Year == period.StartDate.Year)
            .Select(t => t.EventPeriod);

        var blocksForMonth = _calendarBlocks
            .Where(t => t.period.StartDate.Month == period.StartDate.Month
                                && t.period.StartDate.Day == period.StartDate.Day
                                && t.period.StartDate.Year == period.StartDate.Year)
            .Select(t => t.period);

        var occupiedPeriods = appointmentsForMonth.Concat(blocksForMonth).ToList();

        if (occupiedPeriods.OverlapsWith(period))
            throw new DomainException("The slot is not available");

        _appointments.Add(appointment);
    }

    public void SetWorkSchedule(WorkSchedule workSchedule)
    {
        WorkSchedule = workSchedule;
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
        };
    }


    private Doctor() { }

}

