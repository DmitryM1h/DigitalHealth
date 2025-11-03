using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public record struct GetDoctorsFreeSlotsCommand(Guid DoctorId, Period period) : IRequest<IEnumerable<Slot>>;

    //TODO Решить должен ли ссылаться Application на Infrastructure
    internal sealed class GetDoctorsFreeSlotsCommandHandler(IScheduleService _scheduleService) : IRequestHandler<GetDoctorsFreeSlotsCommand, IEnumerable<Slot>>
    {
        public async Task<IEnumerable<Slot>> Handle(GetDoctorsFreeSlotsCommand request, CancellationToken cancellationToken)
        {
            var schedule =  await _scheduleService.GetDoctorScheduleAsync(request.DoctorId, request.period);

            return schedule.Slots;
        }
    }
}
