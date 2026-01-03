using Auth;
using MediatR;

namespace DigitalHealth.Domain.DomainEvents
{
    public record DoctorRegisteredIntegrationEvent(Guid DoctorId, string FullName, string Specialty, int Capacity, Guid ClinicId) : INotification;
    
    
}
