using CSharpFunctionalExtensions;
using DigitalHealth.Domain.Repository;
using Domain.Entities;
using MediatR;


namespace DigitalHealth.Application.Commands.Doctor
{
    public record AddMedicalRecordCommand(Guid DoctorId, Guid PatientId, string? Subjective, string? Prescriptions, string Diagnosis) : IRequest<Result>;

    public class RegisterDoctorCommandHandler(IUnitOfWork _uow) : IRequestHandler<AddMedicalRecordCommand, Result>
    {
        public async Task<Result> Handle(AddMedicalRecordCommand request, CancellationToken cancellationToken)
        {
            var patient = await _uow.Patients.GetPatientById(request.PatientId);

            if (patient is null)
                return Result.Failure("Patient is not found");

            var medicalCard = patient.MedicalCard;

            var record = new MedicalRecord(medicalCard.Id, request.DoctorId, request.Subjective, request.Prescriptions, request.Diagnosis);

            medicalCard.AddRecord(record);

            return Result.Success();

        }
    }
}

