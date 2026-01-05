using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController(IMediator mediator) : ControllerBase
    {

    }
}
