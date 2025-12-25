using Application.Commands;
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


    public record PeriodDto(DateTime startDate, DateTime finishDate);

    [HttpGet("DoctorsFreeSlots")]
    public async Task<IEnumerable<Slot>> GetDoctorsFreeSlots([FromRoute] Guid DoctorId, [FromQuery] PeriodDto period)
    {

        var getDoctorsSlotsCommand = new GetDoctorsFreeSlotsCommand(DoctorId, Period.Create(period.startDate, period.finishDate));
        var result = await mediator.Send(getDoctorsSlotsCommand);
        return result;
    }


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



    public record MakeAppointmentRequest(
    Guid DoctorId,
    DateTime StartDate,
    DateTime EndDate);

    public record MakeAppointpentResponse(Guid DoctorId, Guid PatientId, Period period);

    [HttpPost("users/{patientId}/appointments")]
    public async Task<ActionResult<Appointment>> MakeAppointment([FromRoute] Guid patientId, MakeAppointmentRequest req)
    {

        //var period = Period.Create(req.StartDate, req.EndDate);
        //var app = Appointment.Create(period, req.DoctorId, patientId);

        //var apps = dbContext.Appointments.Where(t => t.EventPeriod.StartDate.Date == req.StartDate.Date && t.DoctorId == patientId).ToList();

        //if (apps.Any(t => t.EventPeriod.StartDate < req.EndDate &&
        //           t.EventPeriod.EndDate > req.StartDate))
        //    return BadRequest("This slot is already occupied");

        //dbContext.Appointments.Add(app);
        //await dbContext.SaveChangesAsync();
        //return Ok(new MakeAppointpentResponse(app.DoctorId, app.PatientId, app.EventPeriod));
        return Ok();
    }


}
