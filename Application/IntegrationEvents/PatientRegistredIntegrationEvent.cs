using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Application.IntegrationEvents
{
    public record PatientRegisteredIntegrationEvent(Guid PatientId, string FullName) : INotification;

}
