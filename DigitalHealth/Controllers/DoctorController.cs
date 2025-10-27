using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DigitalHealth.Controllers;



[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{

    [HttpGet] 
    public async Task<Doctor> GetAllDoctors()
    {

    }


}
