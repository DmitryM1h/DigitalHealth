using Application.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalHealth.Controllers;



[Route("api/[controller]")]
[ApiController]
public class DoctorController(IMediator mediator) : ControllerBase
{

    [HttpGet] 
    public async Task<IEnumerable<Doctor>> GetAllDoctors()
    {
        var getDoctorsCommand = new GetDoctorsCommand();
        var result = await mediator.Send(getDoctorsCommand);
        return result;
    }


}
