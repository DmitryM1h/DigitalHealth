using CSharpFunctionalExtensions;
using DigitalHealth.Domain.Repository;
using Domain.Interfaces;
using Domain.ValueObjects;
using MediatR;



namespace DigitalHealth.Application.Commands.Doctor
{
    public record GetDoctorFreeSlotsCommand(Guid DoctorId, DateOnly Month) : IRequest<Result<Schedule>>;

    public class GetDoctorFreeSlotsCommandHandler(IUnitOfWork _uow, IScheduleService _scheduleService) : IRequestHandler<GetDoctorFreeSlotsCommand, Result<Schedule>>
    {
        public async Task<Result<Schedule>> Handle(GetDoctorFreeSlotsCommand request, CancellationToken cancellationToken)
        {
            if (!await _uow.Doctors.DoctorExists(request.DoctorId))
                return Result.Failure<Schedule>("Doctor was not found");

            var schedule = await _scheduleService.GetDoctorFreeGapsAsync(request.DoctorId, request.Month.ToDateTime(new TimeOnly()));

            return Result.Success(schedule);
        }
    }




}
