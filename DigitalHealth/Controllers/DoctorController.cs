using Application.Commands;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
    public ActionResult<WorkSchedule> GetDoctorsSchedule(Guid doctorId)
    {
        var schedule = dbContext.WorkSchedules.Where(t => t.Doctor.Id == doctorId).FirstOrDefault();

        var response = new {schedule?.Monday, schedule?.Tuesday, schedule?.Thursday, schedule?.Wednesday, schedule?.Friday, schedule?.Saturday, schedule?.Sunday};
        return Ok(response);
    }


    public record PeriodDto(DateTime startDate, DateTime finishDate);


    [HttpGet("DoctorGaps")]
    public async Task<Schedule> GetDoctorsGaps([FromRoute] Guid DoctorId, [FromQuery] YearMonth date, [FromServices] IScheduleService scheduleService)
    {

        return await scheduleService.GetDoctorFreeGapsAsync(DoctorId, date);
    }

    [HttpGet("Appointments")]
    public async Task<IEnumerable<Appointment>> GetDoctorsAppointments([FromRoute] Guid DoctorId)
    {

        return await dbContext.Appointments.Where(t => t.Doctor.Id == DoctorId).ToListAsync();
    }




}
