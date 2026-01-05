using CSharpFunctionalExtensions;
using DigitalHealth.Domain.DomainEvents;
using DigitalHealth.Domain.Repository;
using MediatR;
using Domain.Entities;
using Infrastructure.Data;
using DigitalHealth.Domain.Dto;

namespace DigitalHealth.Application.EventHandlers;


public class DoctorRegistredEventHandler(IUnitOfWork _uow) : INotificationHandler<DoctorRegisteredIntegrationEvent>
{

    public async Task Handle(DoctorRegisteredIntegrationEvent notification, CancellationToken cancellationToken)
    {
        var clinic = await _uow.Clinics.GetClinicAsync(notification.ClinicId);

        var doctorDto = new HireDoctorRequest(notification.DoctorId, notification.FullName, notification.Specialty, notification.Capacity);

        clinic!.HireDoctor(doctorDto);

        await _uow.SaveChangesAsync();
    }
}
