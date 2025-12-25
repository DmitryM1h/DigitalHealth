using Domain.Interfaces;
using Domain.Repository;
using Domain.ValueObjects;


namespace Domain.Services;

public class ScheduleService : IScheduleService
{
    public const int MinimumSlotDuration = 10;

    private IAppointmentDataSource _appointmentDataSource;
    private IScheduleDataSource _scheduleDataSource;
    private ICalendarBlockDataSource _calendarBlockDataSource;

    public ScheduleService(IAppointmentDataSource appointmentDataSource, IScheduleDataSource scheduleDataSource, ICalendarBlockDataSource calendarBlockDataSource)
    {
        _appointmentDataSource = appointmentDataSource;
        _scheduleDataSource = scheduleDataSource;
        _calendarBlockDataSource = calendarBlockDataSource;
    }

    //public async Task<Schedule> GetDoctorScheduleAsync(Guid doctorId, Period period)
    //{
    //    var appointments = await _appointmentDataSource.GetAppointmentsForPeriodAsync(doctorId, period) ?? [];
    //    var doctorsBlocks = await _calendarBlockDataSource.GetDoctorsCalendarBlocksForPeriodAsync(doctorId, period) ?? [];

    //    var blockedPeriods = appointments.Select(t => new { t.EventPeriod.StartDate, t.EventPeriod.EndDate})
    //        .Concat(doctorsBlocks.Select(t => new { t.period.StartDate, t.period.EndDate }))
    //        .ToList();

    //    var doctorSchedule = await _scheduleDataSource.GetDoctorsWorkingSchedule(doctorId);

    //    List<Slot> slots = [];

    //    if (blockedPeriods.Count == 0)
    //    {
    //        slots.Add(new Slot(period));
    //        return Schedule.Create(slots, doctorId, period);
    //    }

    //    foreach (var calendarEventsByDate in blockedPeriods.GroupBy(t => t.StartDate.Date))
    //    {
    //        var workingHours = doctorSchedule.GetWorkingHoursForDay(calendarEventsByDate.Key.Date);

    //        if (!workingHours.IsWorkingDay())
    //            continue;


    //        var currStartDate = GetBeginningOfWorkingDay(DateOnly.FromDateTime(calendarEventsByDate.Key), workingHours!.StartDate!.Value);

    //        foreach (var calendarEvent in calendarEventsByDate.OrderBy(t => t.StartDate))
    //        {

    //            CreateSlotIfValid(currStartDate, calendarEvent.StartDate, slots);

    //            currStartDate = calendarEvent.EndDate;
    //        }

    //        var endOfWorkingDay = calendarEventsByDate.Key.Date + workingHours!.EndDate!.Value.ToTimeSpan();

    //        CreateSlotIfValid(currStartDate, endOfWorkingDay, slots);

    //    }
    //    return Schedule.Create(slots, doctorId, period);


    //}



    public async Task<Schedule> GetDoctorFreeGapsAsync(Guid doctorId, YearMonth yearMonth)
    {

        var daysInMonth = DateTime.DaysInMonth(yearMonth.Year, yearMonth.Month);

        var period = Period.Create(new DateTime(yearMonth.Year, yearMonth.Month, 1), new DateTime(yearMonth.Year, yearMonth.Month, daysInMonth));

        var appointments = await _appointmentDataSource.GetAppointmentsForPeriodAsync(doctorId, period) ?? [];
        var doctorsBlocks = await _calendarBlockDataSource.GetDoctorsCalendarBlocksForPeriodAsync(doctorId, period) ?? [];

        var blockedPeriods = appointments.Select(t => new { t.EventPeriod.StartDate, t.EventPeriod.EndDate })
            .Concat(doctorsBlocks.Select(t => new { t.period.StartDate, t.period.EndDate }))
            .ToList();

        var doctorSchedule = await _scheduleDataSource.GetDoctorsWorkingSchedule(doctorId) ?? throw new Exception("No schedule provided");

        List<SlotsForDay> slotsForDays = [];

        for (int day = 1; day <= daysInMonth; day++)
        {
            List<Slot> slots = [];

            var date = new DateTime(yearMonth.Year, yearMonth.Month, day);

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
    public static DateTime GetEndingOfWorkingDay(DateOnly eventDate, TimeOnly startingHours) => GetDateTimeFromDateAndHours(eventDate, startingHours);


    public static DateTime GetDateTimeFromDateAndHours(DateOnly eventDate, TimeOnly hours)
    {
        return new DateTime(eventDate, hours);
    }


}
