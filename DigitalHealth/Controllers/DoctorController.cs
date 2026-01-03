using DigitalHealth.Application.Commands.Auth;
using DigitalHealth.Application.Requests.Auth;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalHealth.Controllers;



[Route("api/[controller]")]
[ApiController]
public class DoctorController(IMediator mediator, TelemetryContext dbContext) : ControllerBase
{

    [HttpGet("Doctors")]
    public async Task<IEnumerable<Doctor>> GetAllDoctors()
    {
        return await dbContext.Doctors.ToListAsync();
    }

    [HttpGet("Schedule")]
    public ActionResult<WorkSchedule> GetDoctorsSchedule([FromQuery] Guid doctorId)
    {
        var schedule = dbContext.WorkSchedules.Where(t => t.Doctor.Id == doctorId).FirstOrDefault();

        var response = new {schedule?.Monday, schedule?.Tuesday, schedule?.Thursday, schedule?.Wednesday, schedule?.Friday, schedule?.Saturday, schedule?.Sunday};
        return Ok(response);
    }


    [HttpGet("DoctorGaps")]
    public async Task<Schedule> GetDoctorsGaps([FromQuery] Guid doctorId, [FromQuery] DateTime date, [FromServices] IScheduleService scheduleService)
    {

        return await scheduleService.GetDoctorFreeGapsAsync(doctorId, date);
    }


    [HttpPost("Register")]
    //[Authorize(nameof(Role.Administrator))]
    public async Task<ActionResult> RegisterDoctor([FromBody] RegisterDoctorRequest registerDoctorRequest)
    {
        // Сгенерить пароль, потом отправить его доктору на почту. Дать возможность сменить
        var command = new RegisterDoctorCommand(registerDoctorRequest.UserName, registerDoctorRequest.Email, registerDoctorRequest.Password, registerDoctorRequest.PhoneNumber, registerDoctorRequest.ClinicId, registerDoctorRequest.Specialty, registerDoctorRequest.Capacity);

        var result = await mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok();

    }


    [HttpGet("Appointments")]
    public async Task<IEnumerable<DoctorsAppointmentsDto>> GetDoctorsAppointments([FromQuery] Guid doctorId)
    {

        var res = dbContext.Appointments.Where(t => t.Doctor.Id == doctorId).Include(t => t.Patient)
            .Select(t => new DoctorsAppointmentsDto(t.Doctor.Id, t.Patient.Id, t.EventPeriod));

        return res;
    }

    public record DoctorsAppointmentsDto(Guid DoctorId, Guid PatientId,  Period period);




}
