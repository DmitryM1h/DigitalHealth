using CSharpFunctionalExtensions;
using DigitalHealth.Domain.DomainEvents;
using DigitalHealth.Domain.Repository;
using MediatR;
using Domain.Entities;
using Infrastructure.Data;

namespace DigitalHealth.Application.EventHandlers;


public class DoctorRegistredEventHandler(IClinicDataSource _clinicRepository) : INotificationHandler<DoctorRegisteredIntegrationEvent>
{

    public async Task Handle(DoctorRegisteredIntegrationEvent notification, CancellationToken cancellationToken)
    {
        var clinic = await _clinicRepository.GetClinicAsync(notification.ClinicId);

        var doctorDto = new HireDoctorDto(notification.FullName, notification.Specialty, notification.Capacity);

        clinic!.HireDoctor(doctorDto);

        await _clinicRepository.SaveChangesAsync();
    }
}
