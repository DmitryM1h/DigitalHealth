using DigitalHealth.Domain.DomainExceptions;
using Domain.Interfaces;
using Domain.Repository;
using Domain.ValueObjects;


namespace Domain.Services;

public class ScheduleService : IScheduleService
{
    public const int MinimumSlotDuration = 10;

    private IAppointmentRepository _appointmentDataSource;
    private IScheduleRepository _scheduleDataSource;
    private ICalendarBlockRepository _calendarBlockDataSource;

    public ScheduleService(IAppointmentRepository appointmentDataSource, IScheduleRepository scheduleDataSource, ICalendarBlockRepository calendarBlockDataSource)
    {
        _appointmentDataSource = appointmentDataSource;
        _scheduleDataSource = scheduleDataSource;
        _calendarBlockDataSource = calendarBlockDataSource;
    }

    public async Task<Schedule> GetDoctorFreeGapsForMonthAsync(Guid doctorId, DateTime month)
    {

        var daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);

        var period = Period.Create(new DateTime(month.Year, month.Month, 1), new DateTime(month.Year, month.Month, daysInMonth));

        var appointments = await _appointmentDataSource.GetAppointmentsForPeriodAsync(doctorId, period) ?? [];
        var doctorsBlocks = await _calendarBlockDataSource.GetDoctorsCalendarBlocksForPeriodAsync(doctorId, period) ?? [];

        var blockedPeriods = appointments.Select(t => new { t.EventPeriod.StartDate, t.EventPeriod.EndDate })
            .Concat(doctorsBlocks.Select(t => new { t.period.StartDate, t.period.EndDate }))
            .ToList();

        var doctorSchedule = await _scheduleDataSource.GetDoctorsWorkingSchedule(doctorId) ?? throw new DomainException("Doctor must configure working hours first");

        List<SlotsForDay> slotsForDays = [];

        for (int day = 1; day <= daysInMonth; day++)
        {
            List<Slot> slots = [];

            var date = new DateTime(month.Year, month.Month, day);

            var workingHours = doctorSchedule.GetWorkingHoursForDay(date);

            if (!workingHours.IsWorkingDay())
                continue;

            var dayBlockingPeriods = blockedPeriods.Where(t =>
            (t.StartDate.Year, t.StartDate.Month, t.StartDate.Day) == (date.Year, date.Month, date.Day)).ToList();


            var currStartDate = GetBeginningOfWorkingDay(DateOnly.FromDateTime(date), workingHours!.StartDate!.Value);

            foreach (var block in dayBlockingPeriods.OrderBy(t => t.StartDate))
            {
                CreateSlotIfValid(currStartDate, block.StartDate, slots);

                currStartDate = block.EndDate;
            }

            var endOfWorkingDay = GetEndingOfWorkingDay(DateOnly.FromDateTime(date), workingHours.EndDate!.Value);

            CreateSlotIfValid(currStartDate, endOfWorkingDay, slots);

            slotsForDays.Add(new SlotsForDay(slots, DateOnly.FromDateTime(date)));
        }

        return Schedule.Create(slotsForDays, doctorId, period);

    }

    public async Task<SlotsForDay?> GetDoctorFreeGapsForDayAsync(Guid doctorId, DateTime date)
    {
        var dayDate = date.Date;
        var nextDay = dayDate.AddDays(1);

        var period = Period.Create(dayDate, nextDay);

        var appointments = await _appointmentDataSource.GetAppointmentsForPeriodAsync(doctorId, period) ?? [];
        var doctorsBlocks = await _calendarBlockDataSource.GetDoctorsCalendarBlocksForPeriodAsync(doctorId, period) ?? [];

        var blockedPeriods = appointments.Select(t => new { t.EventPeriod.StartDate, t.EventPeriod.EndDate })
            .Concat(doctorsBlocks.Select(t => new { t.period.StartDate, t.period.EndDate }))
            .ToList();

        var doctorSchedule = await _scheduleDataSource.GetDoctorsWorkingSchedule(doctorId)
            ?? throw new DomainException("Doctor must configure working hours first");

        var workingHours = doctorSchedule.GetWorkingHoursForDay(dayDate);

        if (!workingHours.IsWorkingDay())
            return null;

        List<Slot> slots = [];

        var startOfWorkDay = GetBeginningOfWorkingDay(
            DateOnly.FromDateTime(dayDate),
            workingHours.StartDate!.Value);

        var endOfWorkDay = GetEndingOfWorkingDay(
            DateOnly.FromDateTime(dayDate),
            workingHours.EndDate!.Value);

        var dayBlockingPeriods = blockedPeriods
            .Where(t => t.StartDate.Date == dayDate.Date)
            .OrderBy(t => t.StartDate)
            .ToList();

        var currentStart = startOfWorkDay;

        foreach (var block in dayBlockingPeriods)
        {
            CreateSlotIfValid(currentStart, block.StartDate, slots);

            currentStart = block.EndDate;
        }

        CreateSlotIfValid(currentStart, endOfWorkDay, slots);

        var slotsForDay = new SlotsForDay(slots, DateOnly.FromDateTime(dayDate));

        return slotsForDay;
           
    }


    private static void CreateSlotIfValid(DateTime start, DateTime end, List<Slot> slots)
    {

        var period = Period.Create(start, end);

        var slot = new Slot(period);

        var gap = period.EndDate - period.StartDate;

        if (gap < TimeSpan.FromMinutes(MinimumSlotDuration))
        {
            return;
        }

        slots.Add(slot);
    }

    public static DateTime GetBeginningOfWorkingDay(DateOnly eventDate, TimeOnly startingHours) => GetDateTimeFromDateAndHours(eventDate, startingHours);
    public static DateTime GetEndingOfWorkingDay(DateOnly eventDate, TimeOnly endingHours) => GetDateTimeFromDateAndHours(eventDate, endingHours);


    public static DateTime GetDateTimeFromDateAndHours(DateOnly eventDate, TimeOnly hours)
    {
        return new DateTime(eventDate, hours);
    }


}
