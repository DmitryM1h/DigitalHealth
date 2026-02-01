using DigitalHealth.Application.DomainEvents;
using DigitalHealth.Domain.DomainEvents;
using DigitalHealth.Infrastructure.Redis.CachedMembers;
using Domain.Interfaces;
using Domain.ValueObjects;
using MediatR;


namespace DigitalHealth.Application.EventHandlers
{
    internal class AppointmentCreatedDomainEventHandler(CachedScheduleRepository _scheduleCached, IScheduleService _scheduleService) : INotificationHandler<DomainEvent<AppointmentCreatedDomainEvent>>
    {
        //TODO сделать паблиш медиатора асинхронным.
        public async Task Handle(DomainEvent<AppointmentCreatedDomainEvent> notification, CancellationToken cancellationToken)
        {
            var appointmentCreatedEvent = notification._domainEvent;

            var doctorId = appointmentCreatedEvent.DoctorId;

            var appointmentDate = appointmentCreatedEvent.period.StartDate.Date;

            var freeSlotsForDay = await _scheduleService.GetDoctorFreeGapsForDayAsync(doctorId, appointmentDate) 
                        ?? new SlotsForDay(new List<Slot>(), DateOnly.FromDateTime(appointmentDate));

            await _scheduleCached.SetDoctorGapsAsync(doctorId, freeSlotsForDay);
        }
    }
}
