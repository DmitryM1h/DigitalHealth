using Application.Commands;
using Domain.Entities;
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
        var getDoctorsCommand = new GetDoctorsCommand();
        var result = await mediator.Send(getDoctorsCommand);
        return result;
    }


    public record PeriodDto(DateTime startDate, DateTime finishDate);

    [HttpGet("DoctorsFreeSlots")]
    public async Task<IEnumerable<Slot>> GetDoctorsFreeSlots(Guid DoctorId, [FromQuery] PeriodDto period)
    {

        var getDoctorsSlotsCommand = new GetDoctorsFreeSlotsCommand(DoctorId, Period.Create(period.startDate, period.finishDate));
        var result = await mediator.Send(getDoctorsSlotsCommand);
        return result;
    }

    [HttpGet("Appointments")]
    public async Task<IEnumerable<Appointment>> GetDoctorsAppointments(Guid DoctorId)
    {

        return await dbContext.Appointments.Where(t => t.DoctorId == DoctorId).ToListAsync();
    }

    [HttpGet("WorkingSchedule2")]
    public async Task<IEnumerable<Slot>> GetDoctorsFreeeSlots(Guid DoctorId,  PeriodDto period)
    {

        var getDoctorsSlotsCommand = new GetDoctorsFreeSlotsCommand(DoctorId, Period.Create(period.startDate, period.finishDate));
        var result = await mediator.Send(getDoctorsSlotsCommand);
        return result;
    }


}
