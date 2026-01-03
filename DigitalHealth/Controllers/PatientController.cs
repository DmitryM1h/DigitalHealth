using DigitalHealth.Application.Commands.Auth;
using DigitalHealth.Application.Requests.Auth;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    }
}
