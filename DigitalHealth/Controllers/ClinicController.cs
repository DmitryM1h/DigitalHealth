using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalHealth.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController(IMediator mediator)
    {

        [HttpPost("Hire")]
        public async Task HireDoctor(Guid doctorId)
        {

        }

    }
}
