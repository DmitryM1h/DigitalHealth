using DigitalHealth.Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Domain.DomainEvents
{
    public record AppointmentCreatedDomainEvent(Guid DoctorId, Guid PatientId, Period period): IDomainEvent;
 
}
