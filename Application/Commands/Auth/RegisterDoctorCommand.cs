using CSharpFunctionalExtensions;
using DigitalHealth.Auth;
using DigitalHealth.Domain.DomainEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Application.Commands.Auth
{
    public record RegisterDoctorCommand(string UserName, string Email, string Password, string PhoneNumber): IRequest<Result>;


    public class RegisterDoctorCommandHandler(AuthService _authService) : IRequestHandler<RegisterDoctorCommand, Result>
    {
        public async Task<Result> Handle(RegisterDoctorCommand request, CancellationToken cancellationToken)
        { 
            var regDto = new RegisterDoctorDto(request.UserName, request.Email, request.Password, request.PhoneNumber);

            var result = await _authService.RegisterDoctorAsync(regDto, cancellationToken);

            if(result.IsFailure)
            {
                return result;
            }

            //publish и создать уже самого доктора
            return Result.Success();
        }
    }

}
