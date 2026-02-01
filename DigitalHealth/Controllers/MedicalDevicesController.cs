using DigitalHealth.Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DigitalHealth.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MedicalDevicesController(TelemetryContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<MedicalDevice>>> GetDevices()
        {
            var devices = await _context.MedicalDevices.ToListAsync();

            return devices;

        }
    }
}
