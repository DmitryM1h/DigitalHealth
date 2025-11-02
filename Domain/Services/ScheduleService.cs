using Domain.Entities;
using Domain.Interfaces;
using Domain.Repository;
using Domain.ValueObjects;


namespace Domain.Services;

public class ScheduleService : IScheduleService
{
    public const int MinimumSlotDuration = 10;

    private IAppointmentDataSource _appointmentDataSource;

    public ScheduleService(IAppointmentDataSource appointmentDataSource)
    {
        _appointmentDataSource = appointmentDataSource;
    }

    public async Task<Schedule> GetUserScheduleAsync(Guid userId, Period period)
    {
        var appointments = await _appointmentDataSource.GetAppointmentsForPeriodAsync(userId, period);

        List<Slot> slots = [];

        var currStartDate = period.StartDate;

        foreach(var appointment in appointments)
        {

            ProcessGapBeforeAppointment(currStartDate, appointment, slots);

            ProcessAppointment(appointment, slots);

            currStartDate = appointment.EventPeriod.EndDate;


        }

        return Schedule.Create(slots, userId, period);
    }

    public void ProcessGapBeforeAppointment(DateTime currStartDate, Appointment appointment, List<Slot> slots)
    {
        var per = Period.Create(currStartDate, appointment.EventPeriod.StartDate);

        var gap = per.StartDate - per.EndDate;

        var slot = new Slot(per);

        if (gap < TimeSpan.FromMinutes(MinimumSlotDuration))
        {
            slot.LockSlot();
        }

        slots.Add(slot);

    }

    public void ProcessAppointment(Appointment appointment, List<Slot> slots)
    {

        var occupiedPeriod = appointment.EventPeriod;

        var occupiedSlot = new Slot(appointment, occupiedPeriod);

        slots.Add(occupiedSlot);

    }


}
