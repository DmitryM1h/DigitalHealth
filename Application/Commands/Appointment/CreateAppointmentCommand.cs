using CSharpFunctionalExtensions;
using DigitalHealth.Domain.Repository;
using Domain.ValueObjects;
using MediatR;


namespace DigitalHealth.Application.Commands.DoctorCommands;

public record CreateAppointmentCommand(Guid DoctorId, Guid PatientId, Period period) : IRequest<Result>;

public class CreateAppointmentCommandHandler(IUnitOfWork _uow, IMediator _mediator) : IRequestHandler<CreateAppointmentCommand, Result>
{
    public async Task<Result> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _uow.Doctors.GetDoctorById(request.DoctorId);

        var patient = await _uow.Patients.GetPatientById(request.PatientId);

        if (doctor is null || patient is null)
            return Result.Failure("Doctor or patient does not exist");

        var appointment = patient.MakeAppointment(doctor, request.period);

        doctor.ConfirmAppointment(appointment);

        await _uow.SaveChangesAsync();

        return Result.Success();
       
    }
}
