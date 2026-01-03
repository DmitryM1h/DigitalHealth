using DigitalHealth.Application.IntegrationEvents;
using DigitalHealth.Domain.DomainEvents;
using Domain.Entities;
using Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Application.EventHandlers
{
    public class PatientRegistredEventHandler(IPatientRepository _patientRepository) : INotificationHandler<PatientRegisteredIntegrationEvent>
    {

        public async Task Handle(PatientRegisteredIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var patient = Patient.Create(notification.PatientId, notification.FullName);

            await _patientRepository.AddPatientAsync(patient);

            await _patientRepository.SaveChangesAsync();

        }
    }
}
