using DigitalHealth.Application.IntegrationEvents;
using DigitalHealth.Domain.Repository;
using Domain.Entities;
using MediatR;


namespace DigitalHealth.Application.EventHandlers
{
    public class PatientRegistredEventHandler(IUnitOfWork _uow) : INotificationHandler<PatientRegisteredIntegrationEvent>
    {

        public async Task Handle(PatientRegisteredIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var patient = Patient.Create(notification.PatientId, notification.FullName);

            await _uow.Patients.AddPatientAsync(patient);

            await _uow.SaveChangesAsync();

        }
    }
}
