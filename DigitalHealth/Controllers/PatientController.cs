using DigitalHealth.Application.Commands.Auth;
using DigitalHealth.Application.Commands.DoctorCommands;
using DigitalHealth.Application.Requests.Auth;
using DigitalHealth.Auth;
using Domain.ValueObjects;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigitalHealth.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(IMediator mediator) : ControllerBase
    {

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterPatient([FromBody] RegisterPatientRequest registerPatientRequest)
        {
            var command = new RegisterPatientCommand(registerPatientRequest.UserName, registerPatientRequest.Email, registerPatientRequest.Password, registerPatientRequest.PhoneNumber);
            var result = await mediator.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        public record MakeAppointmentDto(Guid DoctorId, DateTime startDate, DateTime endDate);

        [HttpPost("Appointment")]
        [Authorize(Roles = nameof(Role.Patient))]
        public async Task<ActionResult> MakeAppointment([FromBody] MakeAppointmentDto makeappointmentDto)
        {
            var patientId = HttpContext.User.Claims.First(t => t.Type == ClaimTypes.NameIdentifier).Value;
            var command = new CreateAppointmentCommand(makeappointmentDto.DoctorId, Guid.Parse(patientId), makeappointmentDto.startDate, makeappointmentDto.endDate);

            var result = await mediator.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

    }
}
