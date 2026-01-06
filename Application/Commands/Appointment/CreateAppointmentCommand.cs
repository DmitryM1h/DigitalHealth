using CSharpFunctionalExtensions;
using DigitalHealth.Domain.Repository;
using Domain.ValueObjects;
using MediatR;


namespace DigitalHealth.Application.Commands.DoctorCommands;

public record CreateAppointmentCommand(Guid DoctorId, Guid PatientId, DateTime startDate, DateTime endDate) : IRequest<Result>;

public class CreateAppointmentCommandHandler(IUnitOfWork _uow) : IRequestHandler<CreateAppointmentCommand, Result>
{
    public async Task<Result> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var period = Period.Create(request.startDate, request.endDate);

        await _uow.BeginTransactionAsync();

        var doctor = await _uow.Doctors.GetDoctorByIdWithLock(request.DoctorId);

        var patient = await _uow.Patients.GetPatientById(request.PatientId);

        if (doctor is null || patient is null)
            return Result.Failure("Doctor or patient does not exist");

        var appointment = patient.MakeAppointment(doctor, period);

        doctor.ConfirmAppointment(appointment);

        await _uow.SaveChangesAsync();

        await _uow.CommitTransactionAsync();

        return Result.Success();
       
    }
}
