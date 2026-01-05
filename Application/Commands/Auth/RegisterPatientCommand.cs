using CSharpFunctionalExtensions;
using DigitalHealth.Application.IntegrationEvents;
using DigitalHealth.Auth;
using MediatR;


namespace DigitalHealth.Application.Commands.Auth
{
    public record RegisterPatientCommand(string UserName, string Email, string Password, string PhoneNumber) : IRequest<Result>;

    public class RegisterPatientCommandHandler(AuthService _authService, IMediator _mediator) : IRequestHandler<RegisterPatientCommand, Result>
    {
        public async Task<Result> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
        {

            var regDto = new RegisterUserRequest(request.UserName, request.Email, request.Password, request.PhoneNumber);

            var result = await _authService.RegisterUserAsync(regDto, Role.Patient, cancellationToken);

            if (result.IsFailure)
            {
                return result;
            }

            await _mediator.Publish(new PatientRegisteredIntegrationEvent(result.Value.Id, result.Value.UserName!));

            return Result.Success();
        }
    }
}
