using CSharpFunctionalExtensions;
using DigitalHealth.Auth;
using DigitalHealth.Domain.DomainEvents;
using DigitalHealth.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Application.Commands.Auth
{
    public record RegisterDoctorCommand(string UserName, string Email, string Password, string PhoneNumber, Guid clinicId, string Specialty, int capacity): IRequest<Result>;


    public class RegisterDoctorCommandHandler(AuthService _authService, IClinicRepository _clinicRepository, IMediator _mediator) : IRequestHandler<RegisterDoctorCommand, Result>
    {
        public async Task<Result> Handle(RegisterDoctorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await CheckRequirements(request);

            if (!validationResult.IsSuccess)
                return validationResult;

            var regDto = new RegisterDoctorDto(request.UserName, request.Email, request.Password, request.PhoneNumber, request.clinicId, request.Specialty, request.capacity);

            var result = await _authService.RegisterUserAsync(regDto, Role.Doctor, cancellationToken);

            if(result.IsFailure)
            {
                return result;
            }

            await _mediator.Publish(new DoctorRegisteredIntegrationEvent(result.Value.UserName!, request.Specialty, request.capacity, request.clinicId));
            
            return Result.Success();
        }

        private async Task<Result> CheckRequirements(RegisterDoctorCommand request)
        {
            var errors = new List<string>();

            if (await _clinicRepository.GetClinicAsync(request.clinicId) is null)
            {
                errors.Add("Specified clinic was not found");
            }
            
            if (errors.Count > 0)
            {
                return Result.Failure(string.Join(";", errors));
            }
            return Result.Success();
        }
    }

}
